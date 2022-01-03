using FoodForHome.Web.ViewModels.Orders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodForHome.Services.Data
{
    public interface IOrderDetailsService
    {
        Task CreateAsync(OrderDetailsViewModel input, string cartId);

        IEnumerable<T> GetAll<T>(string userId);

        Task DeleteAsync(int dishId, string userId);
    }
}
