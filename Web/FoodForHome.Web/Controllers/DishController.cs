namespace FoodForHome.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using FoodForHome.Common;
    using FoodForHome.Services.Data;
    using FoodForHome.Web.ViewModels.Categories;
    using FoodForHome.Web.ViewModels.Dishes;
    using FoodForHome.Web.ViewModels.Orders;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;

    public class DishController : BaseController
    {
        private readonly ICategoriesService categoriesService;
        private readonly IDishService dishService;
        private readonly IWebHostEnvironment environment;

        public DishController(ICategoriesService categoriesService, IDishService dishService, IWebHostEnvironment environment)
        {
            this.categoriesService = categoriesService;
            this.dishService = dishService;
            this.environment = environment;
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
        public async Task<IActionResult> Create(CreateDishInputModel input)
        {

            if (!this.ModelState.IsValid)
            {
                input.Categories = this.categoriesService.GetCategories();
                return this.View(input);
            }

            try
            {
                await this.dishService.CreateAsync(input, $"{this.environment.WebRootPath}/images");
            }
            catch (Exception ex)
            {

                this.ModelState.AddModelError(string.Empty, ex.Message);
                input.Categories = this.categoriesService.GetCategories();
                return this.View(input);
            }

            this.TempData["Message"] = "Dish added successfully";

            return this.Redirect("/");
        }

        public IActionResult ById(int id)
        {
            var item = this.dishService.GetById<SingleDishViewModel>(id);
            return View(item);
        }

        public IActionResult ByCategory(int id)
        {
            var viewModel = new DishesByCategoryViewModel
            {
                Dishes = this.dishService.GetByCategoryId<DishInMenuViewModel>(id),
            };

            return View(viewModel);
        }
    }
}
