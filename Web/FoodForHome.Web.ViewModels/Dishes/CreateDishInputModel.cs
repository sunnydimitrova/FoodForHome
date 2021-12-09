using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace FoodForHome.Web.ViewModels.Dishes
{
    public class CreateDishInputModel
    {

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }

        [Range(10, 2000)]
        public int Gram { get; set; }

        [Required]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Target Price; Maximum Two Decimal Points.")]
        [Range(0, 9999999999999999.99, ErrorMessage = "Invalid Target Price; Max 18 digits")]
        public string Price { get; set; }

        public int CategoryId { get; set; }

        [Url]
        public string ImageUrl { get; set; }

        public IEnumerable<IFormFile> Images { get; set; }

        [Required]
        public IEnumerable<IngredientInputModel> Ingredients { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
