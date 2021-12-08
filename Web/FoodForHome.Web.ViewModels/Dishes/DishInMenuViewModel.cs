using AutoMapper;
using FoodForHome.Data.Models;
using FoodForHome.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodForHome.Web.ViewModels.Dishes
{
    public class DishInMenuViewModel : IMapFrom<Dish>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public int CategotyId { get; set; }

        public string CategoryName { get; set; }

        public decimal Price { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Dish, DishInMenuViewModel>()
                .ForMember(x => x.ImageUrl, opt =>
                    opt.MapFrom(x =>
                        x.Images.FirstOrDefault().Url != null ?
                        x.Images.FirstOrDefault().Url :
                        "/images/dishes/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extention));
        }
    }
}
