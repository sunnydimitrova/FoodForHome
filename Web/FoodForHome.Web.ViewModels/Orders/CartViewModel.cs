using System;
using System.Collections.Generic;
using System.Text;

namespace FoodForHome.Web.ViewModels.Orders
{
    public class CartViewModel
    {
        public IEnumerable<OrderDetailsViewModel> Items { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
