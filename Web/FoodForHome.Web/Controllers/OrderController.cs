using FoodForHome.Services.Data;
using FoodForHome.Web.ViewModels.Dishes;
using FoodForHome.Web.ViewModels.Favourite;
using FoodForHome.Web.ViewModels.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FoodForHome.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IDishService dishService;
        private readonly IOrderDetailsService orderDetailsService;

        public OrderController(IDishService dishService, IOrderDetailsService orderDetailsService)
        {
            this.dishService = dishService;
            this.orderDetailsService = orderDetailsService;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<OrderDetailsCountModel>> Buy(InputOrderDetailModel input)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var orderDetails = new OrderDetailsViewModel
            {
                Dish = this.dishService.GetById<SingleDishViewModel>(input.DishId),
                Quantity = input.Quantity,
            };
            await this.orderDetailsService.CreateAsync(orderDetails, userId);
            var dishCount = this.orderDetailsService.OrderDetailsCount(userId);

            //return RedirectToAction("Index");
            return new OrderDetailsCountModel { Count = dishCount };
        }

        //[Authorize]
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Remove(int id)
        //{
        //    var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        //    await this.orderDetailsService.DeleteAsync(id, userId);
        //    return NoContent();
        //    //return RedirectToAction("Index");
        //}
    }
}
