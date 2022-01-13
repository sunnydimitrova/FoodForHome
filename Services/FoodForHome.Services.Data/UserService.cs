using FoodForHome.Data.Common.Repositories;
using FoodForHome.Data.Models;
using FoodForHome.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodForHome.Services.Data
{
    public class UserService : IUserService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;
        private readonly IDeletableEntityRepository<Dish> dishRepository;

        public UserService(IDeletableEntityRepository<ApplicationUser> userRepository, IDeletableEntityRepository<Dish> dishRepository)
        {
            this.userRepository = userRepository;
            this.dishRepository = dishRepository;
        }

        public T GetById<T>(string id)
        {
            var user = this.userRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefault();

            return user;
        }

        public async Task AddFavouriteDish(string userId, int dishId)
        {
            var user = this.userRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == userId);

            var dish = this.dishRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == dishId);

            user.Dishes.Add(dish);
            dish.Users.Add(user);
            this.dishRepository.Update(dish);
            this.userRepository.Update(user);
            await this.userRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetFavouriteDish<T>(string userId)
        {
            var dishes = this.userRepository.AllAsNoTracking().Where(x => x.Id == userId)
                .Select(x => x.Dishes).To<T>().ToList<T>();

            return dishes;
        }
    }
}
