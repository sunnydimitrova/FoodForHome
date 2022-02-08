using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FoodForHome.Web.ViewModels.Orders
{
    public class InputOrderDetailModel
    {
        public int DishId { get; set; }

        [Range(1, 100)]
        public int Quantity { get; set; }
    }
}
