using FoodForHome.Data.Common.Repositories;
using FoodForHome.Data.Models;
using FoodForHome.Services.Mapping;
using FoodForHome.Web.ViewModels.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodForHome.Services.Data
{

    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly IRepository<OrderDetail> orderDetailRepository;

        public OrderDetailsService(IRepository<OrderDetail> orderDetailRepository)
        {
            this.orderDetailRepository = orderDetailRepository;
        }

        public async Task CreateAsync(OrderDetailsViewModel input, string userId)
        {
            var orderDetail = this.orderDetailRepository.AllAsNoTracking()
                .FirstOrDefault(x => x.Dish.Id == input.Dish.Id && x.UserId == userId);
            if (orderDetail != null)
            {
                orderDetail.Quantity = orderDetail.Quantity + input.Quantity;

                this.orderDetailRepository.Update(orderDetail);
            }
            else
            {
                orderDetail = new OrderDetail
                {
                    DishId = input.Dish.Id,
                    Quantity = input.Quantity,
                    UserId = userId,
                    UnitPrice = input.Dish.Price,
                    TotalPrice = input.Dish.Price * input.Quantity,
                };
                await this.orderDetailRepository.AddAsync(orderDetail);
            }

            await this.orderDetailRepository.SaveChangesAsync();
        }

        public int OrderDetailsCount(string userId)
        {
            var dishes = this.orderDetailRepository.AllAsNoTracking()
                .Where(x => x.UserId == userId && x.Dish.IsDeleted == false)
                .ToList();
            var count = 0;
            foreach (var item in dishes)
            {
                count += item.Quantity;
            }

            return count;
        }

        public async Task DeleteAsync(int dishId, string userId)
        {
            var deleteDish = this.orderDetailRepository.AllAsNoTracking()
                .Where(x => x.UserId == userId)
                .FirstOrDefault(x => x.Dish.Id == dishId);
            this.orderDetailRepository.Delete(deleteDish);
            await this.orderDetailRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>(string userId)
        {
            var cart = this.orderDetailRepository.AllAsNoTracking()
                .Where(x => x.UserId == userId)
                .To<T>().ToList();

            return cart;
        }
    }
}
