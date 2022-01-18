using FoodForHome.Data.Models;
using FoodForHome.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodForHome.Web.ViewModels.Dishes
{
    public class IngredientViewModel : IMapFrom<DishIngredient>
    {
        public int IngredientId { get; set; }

        public string IngredientName { get; set; }

        public int DishId { get; set; }
    }
}
