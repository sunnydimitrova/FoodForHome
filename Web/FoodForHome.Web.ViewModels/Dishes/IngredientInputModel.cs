using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FoodForHome.Web.ViewModels.Dishes
{
    public class IngredientInputModel
    {

        [Required]
        [MinLength(3)]
        public string IngredientName { get; set; }
    }
}
