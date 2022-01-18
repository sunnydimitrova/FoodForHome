using FoodForHome.Web.ViewModels.Dishes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodForHome.Services.Data
{
    public interface IDishService
    {
        Task CreateAsync(CreateDishInputModel input, string imgPath);

        IEnumerable<T> GetAll<T>();

        IEnumerable<T> GetByCategoryId<T>(int id);

        T GetById<T>(int id);

        Task DeleteDishAsync(int dishId);

        IEnumerable<T> GetByCategoryName<T>(string name);
    }
}
