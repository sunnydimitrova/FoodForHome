namespace FoodForHome.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using FoodForHome.Data.Common.Models;

    public class Image : BaseModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Extention { get; set; }

        public string Url { get; set; }

        public int DishId { get; set; }

        public Dish Dish { get; set; }
    }
}
