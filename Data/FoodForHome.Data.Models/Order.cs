using System;
using System.Collections.Generic;
using System.Text;

using FoodForHome.Data.Common.Models;

namespace FoodForHome.Data.Models
{
    public class Order : BaseDeletableModel<string>
    {
        public Order()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Dishes = new HashSet<Dish>();
        }

        public string Address { get; set; }

        public int UserId { get; set; }

        public decimal Price { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Dish> Dishes { get; set; }
    }
}
