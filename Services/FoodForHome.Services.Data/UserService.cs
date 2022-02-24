using FoodForHome.Data.Common.Repositories;
using FoodForHome.Data.Models;
using FoodForHome.Services.Mapping;
using FoodForHome.Web.ViewModels.Dishes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodForHome.Services.Data
{
    public class UserService : IUserService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;
        private readonly IDeletableEntityRepository<Dish> dishRepository;
        private readonly IDeletableEntityRepository<ApplicationUserDish> userDishRepository;

        public UserService(IDeletableEntityRepository<ApplicationUser> userRepository, IDeletableEntityRepository<Dish> dishRepository, 
        IDeletableEntityRepository<ApplicationUserDish> userDishRepository)
        {
            this.userRepository = userRepository;
            this.dishRepository = dishRepository;
            this.userDishRepository = userDishRepository;
        }

        public T GetById<T>(string id)
        {
            var user = this.userRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefault();

            return user;
        }

        public async Task AddFavouriteDish(string userId, int dishId)
        {
            var user = this.userRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == userId);
            var dish = this.dishRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == dishId);

            user.Dishes.Add(new ApplicationUserDish
            {
                 Dish = dish,
            });

            this.userRepository.Update(user);
            await this.userRepository.SaveChangesAsync();
        }

        public async Task DeleteFavouriteDish(string userId, int dishId)
        {
            var userDish = this.userDishRepository.AllAsNoTracking()
                .FirstOrDefault(x => x.ApplicationUserId == userId && x.DishId == dishId);

            this.userDishRepository.Delete(userDish);
            await this.userRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetUserFavouriteDishes<T>(string userId)
        {
            var dishes = this.userDishRepository.All()
                .Where(x => x.ApplicationUserId == userId)
                .Select(x => new Dish
                {
                    Id = x.DishId,
                    Name = x.Dish.Name,
                    CategoryId = x.Dish.CategoryId,
                    Category = x.Dish.Category,
                    Images = x.Dish.Images,
                    Gram = x.Dish.Gram,
                    Price = x.Dish.Price,
                })
                .To<T>()
                .ToList();
            return dishes;
        }
    }
}
