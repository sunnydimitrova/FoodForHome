using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

using FoodForHome.Data.Common.Models;

namespace FoodForHome.Data.Models
{
    public class Dish : BaseDeletableModel<int>
    {
        public Dish()
        {
            this.Ingredients = new HashSet<Ingredient>();
            this.Images = new HashSet<Image>();
            this.Users = new HashSet<ApplicationUser>();
        }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public int Gram { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
