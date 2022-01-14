using FoodForHome.Data.Models;
using FoodForHome.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodForHome.Web.ViewModels.Dishes
{
    public class UserDishesViewModel : IMapFrom<ApplicationUserDish>
    {
        public int DishId { get; set; }

        public string ApplicationUserId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
