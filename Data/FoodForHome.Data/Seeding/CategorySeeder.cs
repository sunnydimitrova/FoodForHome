namespace FoodForHome.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FoodForHome.Data.Models;

    internal class CategorySeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            await dbContext.Categories.AddAsync(new Category { Name = "Salads" });
            await dbContext.Categories.AddAsync(new Category { Name = "Appetizers" });
            await dbContext.Categories.AddAsync(new Category { Name = "Soups" });
            await dbContext.Categories.AddAsync(new Category { Name = "Pizza" });
            await dbContext.Categories.AddAsync(new Category { Name = "Pasta and Risotto" });
            await dbContext.Categories.AddAsync(new Category { Name = "Main dishes of chicken" });
            await dbContext.Categories.AddAsync(new Category { Name = "Main dishes of pork" });
            await dbContext.Categories.AddAsync(new Category { Name = "Main dishes of beef" });
            await dbContext.Categories.AddAsync(new Category { Name = "Main dishes of fish" });
            await dbContext.Categories.AddAsync(new Category { Name = "Grill" });
            await dbContext.Categories.AddAsync(new Category { Name = "Desserts" });
            await dbContext.Categories.AddAsync(new Category { Name = "Lunch menu" });

            await dbContext.SaveChangesAsync();
        }
    }
}
