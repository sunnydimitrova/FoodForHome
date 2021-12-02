using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FoodForHome.Web.ViewModels.Dish
{
    public class CreateDishInputModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required]
        [Range(10, 2000)]
        public int Gram { get; set; }

        [Required]
        [Range(1.00, 500.00)]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        [Url]
        public string ImageUrl { get; set; }

        public IEnumerable<IFormFile> Images { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Categories { get; set; }

        public virtual IEnumerable<IngredientInputModel> Ingredients { get; set; }
    }
}
