using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

using FoodForHome.Data.Common.Models;

namespace FoodForHome.Data.Models
{
    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.Dishes = new HashSet<Dish>();
        }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public virtual ICollection<Dish> Dishes { get; set; }
    }
}
