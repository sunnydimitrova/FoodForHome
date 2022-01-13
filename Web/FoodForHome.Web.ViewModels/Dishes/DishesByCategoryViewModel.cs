using System;
using System.Collections.Generic;
using System.Text;

namespace FoodForHome.Web.ViewModels.Dishes
{
    public class DishesByCategoryViewModel
    {
        public IEnumerable<DishInMenuViewModel> Dishes { get; set; }
    }
}
