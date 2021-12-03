﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace FoodForHome.Web.ViewModels.Dish
{
    public class CreateDishInputModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        public string Name { get; set; }

        [Range(10, 2000)]
        public int Gram { get; set; }

        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Target Price; Maximum Two Decimal Points.")]
        [Range(0, 9999999999999999.99, ErrorMessage = "Invalid Target Price; Max 18 digits")]
        public decimal Price { get; set; }

        [Required]
        [RegularExpression(@"^([a-zA-Z]+\,{1}\s{1})+[a-zA-Z]+$", ErrorMessage = "The ingredients must be in the format described in brackets above")]
        public string Ingredients { get; set; }

        public int CategoryId { get; set; }

        [Url]
        public string ImageUrl { get; set; }

        public IEnumerable<IFormFile> Images { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
