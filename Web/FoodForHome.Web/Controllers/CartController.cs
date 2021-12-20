namespace FoodForHome.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using FoodForHome.Services.Data;
    using FoodForHome.Web.Helpers;
    using FoodForHome.Web.ViewModels.Dishes;
    using FoodForHome.Web.ViewModels.Orders;
    using Microsoft.AspNetCore.Mvc;

    public class CartController : Controller
    {
        private readonly IDishService dishService;

        public CartController(IDishService dishService)
        {
            this.dishService = dishService;
        }

        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<OrderDetailsViewModel>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(x => x.Dish.Price * x.Quantity);
            return View();
        }

        private int isExist(int id)
        {
            List<OrderDetailsViewModel> cart = SessionHelper.GetObjectFromJson<List<OrderDetailsViewModel>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Dish.Id.Equals(id))
                {
                    return i;
                }
            }

            return -1;
        }

        public IActionResult Buy(int id)
        {
            if (SessionHelper.GetObjectFromJson<List<OrderDetailsViewModel>>(HttpContext.Session, "cart") == null)
            {
                var cart = new List<OrderDetailsViewModel>();
                cart.Add(new OrderDetailsViewModel { Dish = this.dishService.GetById<SingleDishViewModel>(id), Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<OrderDetailsViewModel> cart = SessionHelper.GetObjectFromJson<List<OrderDetailsViewModel>>(HttpContext.Session, "cart");
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new OrderDetailsViewModel { Dish = this.dishService.GetById<SingleDishViewModel>(id), Quantity = 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            List<OrderDetailsViewModel> cart = SessionHelper.GetObjectFromJson<List<OrderDetailsViewModel>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }
    }
}
