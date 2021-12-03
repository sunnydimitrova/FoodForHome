using FoodForHome.Data.Common.Repositories;
using FoodForHome.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodForHome.Services.Data
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepository;

        public CategoriesService(IDeletableEntityRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public IEnumerable<SelectListItem> GetCategories()
        {
            return this.categoriesRepository.AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                })
                .ToList()
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()));
        }

        //public IEnumerable<KeyValuePair<string, string>> GetCategoriesAsKeyValuePair()
        //{
        //    return this.categoriesRepository.AllAsNoTracking()
        //        .Select(x => new
        //        {
        //            x.Id,
        //            x.Name,
        //        })
        //        .OrderBy(x => x.Id)
        //        .ToList()
        //        .Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        //}
    }
}
