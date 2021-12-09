using FoodForHome.Data.Models;
using FoodForHome.Services.Mapping;
using FoodForHome.Web.ViewModels.Categories;
using FoodForHome.Web.ViewModels.Dishes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodForHome.Web.ViewModels.Menu
{
    public class MenuViewModel
    {
        public IEnumerable<CategoryViewModel> Categories { get; set; }

        public IEnumerable<DishInMenuViewModel> Dishes { get; set; }
    }
}
