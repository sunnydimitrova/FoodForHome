using AutoMapper;
using FoodForHome.Data.Models;
using FoodForHome.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodForHome.Web.ViewModels.Dishes
{
    public class SingleDishViewModel : IMapFrom<Dish>, IHaveCustomMappings
    {

        public int Id { get; set; }

        public string UserId { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public int Gram { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public decimal Price { get; set; }

        public IEnumerable<UserDishesViewModel> UserDishes { get; set; }

        public IEnumerable<IngredientViewModel> Ingredients { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Dish, SingleDishViewModel>()
                .ForMember(x => x.UserDishes, opt =>
                opt.MapFrom(x => x.Users))
                .ForMember(x => x.ImageUrl, opt =>
                    opt.MapFrom(x =>
                        x.Images.FirstOrDefault().Url != null ?
                        x.Images.FirstOrDefault().Url :
                        "/images/dishes/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extention));
        }
    }
}
