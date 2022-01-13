using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodForHome.Services.Data
{
    public interface ICategoriesService
    {
        IEnumerable<SelectListItem> GetCategories();

        IEnumerable<T> GetAll<T>();

    }
}
