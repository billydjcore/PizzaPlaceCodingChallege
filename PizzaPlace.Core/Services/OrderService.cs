using PizzaPlace.Core.DTO;
using PizzaPlace.Core.Entities;
using PizzaPlace.Core.RepositoryContracts;
using PizzaPlace.Core.ServiceContracts;

namespace PizzaPlace.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrdersRepository _iOrdersRepository;
        public OrderService(IOrdersRepository ordersRepository)
        {
            _iOrdersRepository = ordersRepository;
        }

        public async Task<bool> DeleteOrder(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return await _iOrdersRepository.DeleteOrder(id);
        }

        public async Task<Order?> GetOrder(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return await _iOrdersRepository.GetOrder(id);
        }

        public async Task<IEnumerable<Order>?> Getorders()
        {
            return await _iOrdersRepository.GetOrders();
        }

        public async Task<bool> PostOrder(OrderRequest? order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));
        
            if (string.IsNullOrEmpty(order.date))
                throw new ArgumentNullException(nameof(order.date));

            if (string.IsNullOrEmpty(order.time))
                throw new ArgumentNullException(nameof(order.time));

            return await _iOrdersRepository.PostOrder(order);         
        }

        public async Task<bool> PutOrder(int? id, Order? order)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            if (order == null)
                throw new ArgumentNullException(nameof(order));
            if (order.order_id == null)
                throw new ArgumentNullException(nameof(order.order_id));
            if (string.IsNullOrEmpty(order.date))
                throw new ArgumentNullException(nameof(order.date));
            if (string.IsNullOrEmpty(order.time))
                throw new ArgumentNullException(nameof(order.time));

            return await _iOrdersRepository.PutOrder(id, order);
        }

    }
}
