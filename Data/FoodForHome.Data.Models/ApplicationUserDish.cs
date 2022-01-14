namespace FoodForHome.Data.Models
{
    using FoodForHome.Data.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class ApplicationUserDish : BaseDeletableModel<int>
    {
        public int DishId { get; set; }

        public virtual Dish Dish { get; set; }

        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
