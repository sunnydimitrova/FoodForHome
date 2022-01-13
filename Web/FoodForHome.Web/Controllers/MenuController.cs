using FoodForHome.Common;
using FoodForHome.Services.Data;
using FoodForHome.Web.ViewModels.Categories;
using FoodForHome.Web.ViewModels.Dishes;
using FoodForHome.Web.ViewModels.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodForHome.Web.Controllers
{
    public class MenuController : Controller
    {
        private readonly ICategoriesService categoriesService;
        private readonly IDishService dishService;

        public MenuController(ICategoriesService categoriesService, IDishService dishService)
        {
            this.categoriesService = categoriesService;
            this.dishService = dishService;
        }

        public IActionResult Categories()
        {
            var viewModel = new CategoriesViewModel
            {
                Categories = this.categoriesService.GetAll<CategoryViewModel>(),
            };

            return View(viewModel);
        }
    }
}
