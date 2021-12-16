using FoodForHome.Data.Models;
using FoodForHome.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodForHome.Web.ViewModels.Dishes
{
    public class IngredientViewModel : IMapFrom<Ingredient>
    {
        public string Name { get; set; }
    }
}
