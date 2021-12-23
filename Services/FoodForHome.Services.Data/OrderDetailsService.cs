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

        public async Task CreateAsync(OrderDetailsViewModel input, string cartId)
        {
            var orderDetail = this.orderDetailRepository.AllAsNoTracking().FirstOrDefault(x => x.Dish.Id == input.Dish.Id);
            if (orderDetail != null)
            {
                orderDetail.Quantity = orderDetail.Quantity + 1;

                this.orderDetailRepository.Update(orderDetail);
            }
            else
            {
                orderDetail = new OrderDetail
                {
                    DishId = input.Dish.Id,
                    Quantity = input.Quantity,
                    CartId = cartId,
                    UnitPrice = input.Dish.Price,
                    TotalPrice = input.Dish.Price * input.Quantity,
                };
                await this.orderDetailRepository.AddAsync(orderDetail);
            }
            await this.orderDetailRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int dishId)
        {
            var deleteDish = this.orderDetailRepository.AllAsNoTracking()
                .FirstOrDefault(x => x.Dish.Id == dishId);
            this.orderDetailRepository.Delete(deleteDish);
            await this.orderDetailRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>(string userId)
        {
            var orderDetails = this.orderDetailRepository.AllAsNoTracking()
                .Where(x => x.CartId == userId)
                .To<T>().ToList();

            return orderDetails;
        }
    }
}
