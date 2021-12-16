using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

using FoodForHome.Data.Common.Models;

namespace FoodForHome.Data.Models
{
    public class Ingredient : BaseDeletableModel<int>
    {
        public Ingredient()
        {
            this.Dishes = new HashSet<Dish>();
            this.Users = new HashSet<ApplicationUser>();
        }

        [Required]
        [MaxLength(15)]
        public string Name { get; set; }

        public virtual ICollection<Dish> Dishes { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
