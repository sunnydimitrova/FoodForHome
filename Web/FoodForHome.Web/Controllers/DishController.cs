namespace FoodForHome.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using FoodForHome.Common;
    using FoodForHome.Services.Data;
    using FoodForHome.Web.ViewModels.Dish;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class DishController : BaseController
    {
        private readonly ICategoriesService categoriesService;

        public DishController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Create()
        {
            var viewModel = new CreateDishInputModel();
            viewModel.Categories = this.categoriesService.GetCategories();
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Create(CreateDishInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.Categories = this.categoriesService.GetCategories();
                return this.View(input);
            }

            return this.Redirect("/");
        }
    }
}
