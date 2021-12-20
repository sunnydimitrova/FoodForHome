using FoodForHome.Data.Models;
using FoodForHome.Services.Mapping;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodForHome.Web.ViewModels.Dishes
{
    public class EditDishInputModle : SingleDishViewModel, IMapFrom<Dish>
    {
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
