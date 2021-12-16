﻿using FoodForHome.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodForHome.Data.Models
{
    public class OrderDetail : BaseModel<int>
    {
        public string OrderId { get; set; }

        public virtual Order Order { get; set; }

        public int DishId { get; set; }

        public virtual Dish Dish { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TotalPrice { get; set; }

        public int Quantity { get; set; }
    }
}