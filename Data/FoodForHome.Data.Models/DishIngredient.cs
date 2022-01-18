using FoodForHome.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodForHome.Data.Models
{
    public class DishIngredient : BaseDeletableModel<int>
    {
        public int DishId { get; set; }

        public virtual Dish Dish { get; set; }

        public int IngredientId { get; set; }

        public virtual Ingredient Ingredient { get; set; }
    }
}
