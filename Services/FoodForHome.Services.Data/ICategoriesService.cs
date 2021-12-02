using System;
using System.Collections.Generic;
using System.Text;

namespace FoodForHome.Services.Data
{
    public interface ICategoriesService
    {
        IEnumerable<KeyValuePair<string, string>> GetCategoriesAsKeyValuePair();
    }
}
