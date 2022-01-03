namespace FoodForHome.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using FoodForHome.Services.Data;
    using FoodForHome.Web.Helpers;
    using FoodForHome.Web.ViewModels.Dishes;
    using FoodForHome.Web.ViewModels.Orders;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class CartController : Controller
    {
        private readonly IDishService dishService;
        private readonly IOrderDetailsService orderDetailsService;

        public CartController(IDishService dishService, IOrderDetailsService orderDetailsService)
        {
            this.dishService = dishService;
            this.orderDetailsService = orderDetailsService;
        }

        [Authorize]
        public IActionResult Index()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var cart = new CartViewModel
            {
                Items = this.orderDetailsService.GetAll<OrderDetailsViewModel>(userId),
            };
            cart.TotalPrice = cart.Items.Sum(x => x.Dish.Price * x.Quantity);
            return View(cart);
        }

        [Authorize]
        public async Task<IActionResult> Buy(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var orderDetails = new OrderDetailsViewModel
            {
                Dish = this.dishService.GetById<SingleDishViewModel>(id),
                Quantity = 1,
            };
            await this.orderDetailsService.CreateAsync(orderDetails, userId);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.orderDetailsService.DeleteAsync(id, userId);
            return RedirectToAction("Index");
        }
    }
}
