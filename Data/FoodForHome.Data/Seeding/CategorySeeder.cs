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

            await dbContext.Categories.AddAsync(new Category { Name = "Salads" , ImageUrl = "https://mysubway.bg/wp-content/uploads/2020/11/Chipotle-salad-400x300.jpg" });
            await dbContext.Categories.AddAsync(new Category { Name = "Appetizers", ImageUrl = "https://www.schaer.com/sites/default/files/2143_Corn%20Flakes%20Chicken%20Fingers.jpg" });
            await dbContext.Categories.AddAsync(new Category { Name = "Soups", ImageUrl = "https://www.thespruceeats.com/thmb/odmvd5m909NmJc-OPAcVA_Jery4=/4000x3000/smart/filters:no_upscale()/vegetarian-bean-and-barley-vegetable-soup-3377970_15-5b3f810146e0fb003758ff8b.jpg" });
            await dbContext.Categories.AddAsync(new Category { Name = "Pizza", ImageUrl = "https://zavedenia.com/zimages/plovdiv/big/1688/1688FFWNOWmT9r3coyznnB8lCHC6PR1jweRcUNZ.jpg" });
            await dbContext.Categories.AddAsync(new Category { Name = "Pasta and Risotto", ImageUrl = "https://www.grilledhut.com.au/javascript/uploads/2020/04/Pasta-Risotto-scaled.jpg" });
            await dbContext.Categories.AddAsync(new Category { Name = "Main dishes of chicken", ImageUrl = "https://recipes.timesofindia.com/photo/62711151.cms" });
            await dbContext.Categories.AddAsync(new Category { Name = "Main dishes of pork", ImageUrl = "https://www.mygreekdish.com/wp-content/uploads/2013/05/Greek-style-Roast-Pork-750x563.jpg" });
            await dbContext.Categories.AddAsync(new Category { Name = "Main dishes of beef", ImageUrl = "https://welaughwecrywecook.files.wordpress.com/2014/04/dsc_0021.jpg" });
            await dbContext.Categories.AddAsync(new Category { Name = "Main dishes of fish", ImageUrl = "https://thehealthyfish.com/wp-content/uploads/2018/04/mediterraneanfishrecipes_1280px_46cda864e66f4699bbb0dcd586476d81-1280x720.jpeg" });
            await dbContext.Categories.AddAsync(new Category { Name = "Grill", ImageUrl = "https://www.mashed.com/img/gallery/the-dangerous-side-effect-of-eating-too-much-grilled-meat/l-intro-1625764453.jpg" });
            await dbContext.Categories.AddAsync(new Category { Name = "Desserts", ImageUrl = "https://images.immediate.co.uk/production/volatile/sites/30/2020/08/dessert-main-image-molten-cake-0fbd4f2.jpg" });
            await dbContext.Categories.AddAsync(new Category { Name = "Lunch menu", ImageUrl = "https://static.framar.bg/thumbs/6/recepies/181017125656bob-s-nadenitsa.jpg" });

            await dbContext.SaveChangesAsync();
        }
    }
}
