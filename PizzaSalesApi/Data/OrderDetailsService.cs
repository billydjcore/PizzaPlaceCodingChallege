using Microsoft.EntityFrameworkCore;
using PizzaPlace.Api.Services;
using PizzaPlaceApi.Data;
using PizzaPlaceApi.Data.Models;

namespace PizzaPlace.Api.Data
{
    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly ApplicationDbContext _context;
        public OrderDetailsService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<bool> DeleteOrderDetails(int? id)
        {
            bool isDeleted = false;
            OrderDetails? foundOrderDetail = _context.order_details.Find(id);
            if(foundOrderDetail != null) 
            {
                _context.order_details.Remove(foundOrderDetail);
                await _context.SaveChangesAsync();
                isDeleted = true;
            }
            return isDeleted;
        }

        public async Task<OrderDetails?> GetOrderDetail(int? id)
        {
            return await _context.order_details.FindAsync(id);
        }

        public async Task<IEnumerable<OrderDetails>?> GetListOfOrder_details(int? orderId)
        {
            return await _context.order_details.Where(o => o.order_id.Equals(orderId)).ToListAsync();
        }

        public bool OrderDetailsExists(int? id)
        {
            bool isExist = false;
            var orderDetails = _context.order_details.Find(id);
            if (orderDetails != null)
            {
                isExist = true;
            }
            return isExist;
        }

        public async Task<OrderDetails?> PostOrderDetails(OrderDetails? orderDetails)
        {
            _context.order_details.Add(orderDetails);
            await _context.SaveChangesAsync();
            return orderDetails;
        }

        public async Task<bool> PutOrderDetails(int? id, OrderDetails? orderDetails)
        {
            bool isUpdated = false;

            OrderDetails? foundOrderDetails = await _context.order_details.FindAsync(id);
            if (foundOrderDetails != null)
            {
                _context.Entry(foundOrderDetails).State = EntityState.Modified;
                foundOrderDetails.quantity = orderDetails.quantity;
                foundOrderDetails.pizza_id = orderDetails.pizza_id;
                await _context.SaveChangesAsync();
                isUpdated = true;
            }
           
            return isUpdated;
        }
    }
}
