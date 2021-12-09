using FoodForHome.Data.Models;
using FoodForHome.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodForHome.Web.ViewModels.Categories
{
    public class CategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

    }
}
