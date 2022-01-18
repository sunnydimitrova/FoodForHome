using System.Diagnostics;
using System.Security.Claims;
using FoodForHome.Services.Data;
using FoodForHome.Web.ViewModels;
using FoodForHome.Web.ViewModels.Dishes;
using Microsoft.AspNetCore.Mvc;

namespace FoodForHome.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IDishService dishService;
        private readonly IUserService userService;

        public HomeController(IDishService dishService, IUserService userService)
        {
            this.dishService = dishService;
            this.userService = userService;
        }

        public IActionResult Index()
        {
            var viewModel = new DishesByCategoryViewModel
            {
                Dishes = this.dishService.GetByCategoryName<DishInMenuViewModel>("Lunch menu"),
            };
            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {

            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
