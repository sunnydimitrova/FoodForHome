using FoodForHome.Services.Data;
using FoodForHome.Web.ViewModels.Favourite;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FoodForHome.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavouriteController : BaseController
    {
        private readonly IUserService userService;

        public FavouriteController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok("Api controller");
        }

        [Authorize]
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult<ResponceFavouriteModel>> Post(InputFavouriteModel input)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.userService.AddFavouriteDish(userId, input.DishId);
            return new ResponceFavouriteModel { Message = "Add succesful" };
        }
    }
}
