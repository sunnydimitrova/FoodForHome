namespace FoodForHome.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FoodForHome.Data.Common.Repositories;
    using FoodForHome.Data.Models;
    using FoodForHome.Services.Mapping;
    using FoodForHome.Web.ViewModels.Dishes;

    public class DishService : IDishService
    {
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif" };
        private readonly IDeletableEntityRepository<Dish> dishRepository;
        private readonly IDeletableEntityRepository<Ingredient> ingredientRepository;

        public DishService(IDeletableEntityRepository<Dish> dishRepository, IDeletableEntityRepository<Ingredient> ingredientRepository)
        {
            this.dishRepository = dishRepository;
            this.ingredientRepository = ingredientRepository;
        }

        public async Task CreateAsync(CreateDishInputModel input, string imgPath)
        {
            var price = decimal.Parse(input.Price, CultureInfo.InvariantCulture);

            var dish = new Dish
            {
               Name = input.Name,
               Gram = input.Gram,
               Price = price,
               CategoryId = input.CategoryId,
            };

            foreach (var currIngredient in input.Ingredients)
            {
                var ingredient = this.ingredientRepository.All().FirstOrDefault(x => x.Name == currIngredient.IngredientName);
                if (ingredient == null)
                {
                    ingredient = new Ingredient
                    {
                        Name = currIngredient.IngredientName,
                    };
                }

                dish.Ingredients.Add(new DishIngredient { Ingredient = ingredient, Dish = dish });
            }

            if (input.Images.Count() == 0)
            {
                dish.Images.FirstOrDefault().Url = input.ImageUrl;
            }
            else
            {
                Directory.CreateDirectory($"{imgPath}/dishes/");
                foreach (var image in input.Images)
                {
                    var extention = Path.GetExtension(image.FileName).TrimStart('.');
                    if (!this.allowedExtensions.Any(x => extention.EndsWith(x)))
                    {
                        throw new Exception($"Invalid image extention {extention}");
                    }

                    var dbImage = new Image
                    {
                        Extention = extention,
                        Url = input.ImageUrl,
                    };

                    dish.Images.Add(dbImage);

                    var path = $"{imgPath}/dishes/{dbImage.Id}.{extention}";
                    using Stream fileStream = new FileStream(path, FileMode.Create);
                    await image.CopyToAsync(fileStream);
                }
            }

            await this.dishRepository.AddAsync(dish);
            await this.dishRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>()
        {
            var dishes = this.dishRepository.AllAsNoTracking()
                .OrderBy(x => x.CategoryId)
                .To<T>().ToList();

            return dishes;
        }

        public IEnumerable<T> GetByCategoryId<T>(int id)
        {
            var dishes = this.dishRepository.AllAsNoTracking()
                .Where(x => x.CategoryId == id)
                .To<T>().ToList();

            return dishes;
        }

        public IEnumerable<T> GetByCategoryName<T>(string name)
        {
            var dishes = this.dishRepository.AllAsNoTracking()
                .Where(x => x.Category.Name == name)
                .To<T>().ToList();

            return dishes;
        }

        public T GetById<T>(int id)
        {
            var dish = this.dishRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefault();

            return dish;
        }

        public async Task DeleteDishAsync(int dishId)
        {
            var dish = this.dishRepository.AllAsNoTracking()
                .Where(x => x.Id == dishId).FirstOrDefault();
            this.dishRepository.Delete(dish);
            await this.dishRepository.SaveChangesAsync();
        }
    }
}
