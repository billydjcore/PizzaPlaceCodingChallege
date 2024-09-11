using Microsoft.EntityFrameworkCore;
using PizzaPlace.Api.Services;
using PizzaPlaceApi.Data;
using PizzaPlaceApi.Data.Models;

namespace PizzaPlace.Api.Data
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;
        public OrderService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<bool> DeleteOrder(int? id)
        {
            bool isDeleted = false;
            Order? foundOrder = _context.orders.Find(id);
            if (foundOrder != null)
            {
                _context.orders.Remove(foundOrder);
                await _context.SaveChangesAsync();
                isDeleted = true;
            }
            return isDeleted;
        }

        public async Task<Order?> GetOrder(int? id)
        {
            return await _context.orders.FindAsync(id);
        }

        public async Task<IEnumerable<Order>?> Getorders()
        {
            return await _context.orders.ToListAsync();
        }

        public bool OrderExists(int? id)
        {
            bool isExist = false;
            Order? orderFound =  _context.orders.Find(id);
            if (orderFound != null)
            {
                isExist = true;
            }
            return isExist;
        }

        public async Task<Order?> PostOrder(Order? order)
        {
            _context.orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<bool> PutOrder(int? id, Order? order)
        {
            bool isUpdated = false;

            Order? foundOrder = _context.orders.Find(id);
            if (foundOrder != null)
            {
                _context.Entry(foundOrder).State = EntityState.Modified;
                foundOrder.date = order.date;
                foundOrder.time = order.time;
                await _context.SaveChangesAsync();
                isUpdated = true;
            }
           
            return isUpdated;
        }
    }
}
