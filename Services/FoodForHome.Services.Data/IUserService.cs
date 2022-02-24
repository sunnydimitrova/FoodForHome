using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodForHome.Services.Data
{
    public interface IUserService
    {
        T GetById<T>(string id);

        Task AddFavouriteDish(string userId, int dishId);

        Task DeleteFavouriteDish(string userId, int dishId);

        IEnumerable<T> GetUserFavouriteDishes<T>(string userId);
    }
}
