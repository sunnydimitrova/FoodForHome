using FoodForHome.Data.Common.Repositories;
using FoodForHome.Data.Models;
using FoodForHome.Services.Mapping;
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

        public IEnumerable<T> GetAll<T>()
        {
            var categories = this.categoriesRepository.AllAsNoTracking()
                .OrderBy(x => x.Id)
                .To<T>().ToList();

            return categories;
        }

    }
}
