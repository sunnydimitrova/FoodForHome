namespace FoodForHome.Web.ViewModels.Orders
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using FoodForHome.Data.Models;
    using FoodForHome.Services.Mapping;
    using FoodForHome.Web.ViewModels.Dishes;

    public class OrderDetailsViewModel : IMapFrom<OrderDetail>
    {
        public SingleDishViewModel Dish { get; set; }

        public int Quantity { get; set; }
    }
}
