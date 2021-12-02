namespace FoodForHome.Web.ViewModels.Dish
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class IngredientInputModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        public string Name { get; set; }
    }
}
