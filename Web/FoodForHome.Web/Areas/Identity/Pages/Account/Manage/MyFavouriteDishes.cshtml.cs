using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FoodForHome.Services.Data;
using FoodForHome.Web.ViewModels.Dishes;
using FoodForHome.Web.ViewModels.Favourite;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodForHome.Web.Areas.Identity.Pages.Account.Manage
{
    public class MyFavouriteDishesModel : PageModel
    {
        private readonly IUserService userService;

        public MyFavouriteDishesModel(IUserService userService)
        {
            this.userService = userService;
}

        public IEnumerable<DishInMenuViewModel> Dishes { get; set; }

        public IActionResult OnGet()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            this.Dishes = this.userService.GetUserFavouriteDishes<DishInMenuViewModel>(userId);

            return Page();
        }
    }
}
