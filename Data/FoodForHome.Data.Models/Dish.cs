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
            this.Ingredients = new HashSet<DishIngredient>();
            this.Images = new HashSet<Image>();
            this.Users = new HashSet<ApplicationUserDish>();
        }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public int Gram { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public virtual ICollection<DishIngredient> Ingredients { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<ApplicationUserDish> Users { get; set; }
    }
}
