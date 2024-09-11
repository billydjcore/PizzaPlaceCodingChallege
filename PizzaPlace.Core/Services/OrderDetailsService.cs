using PizzaPlace.Core.DTO;
using PizzaPlace.Core.Entities;
using PizzaPlace.Core.RepositoryContracts;
using PizzaPlace.Core.ServiceContracts;

namespace PizzaPlace.Core.Services
{
    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly IOrderDetailsRepository _orderDetailsRepository;
        public OrderDetailsService(IOrderDetailsRepository orderDetailsRepository)
        {
            _orderDetailsRepository = orderDetailsRepository;
        }

        public async Task<bool> DeleteOrderDetails(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return await _orderDetailsRepository.DeleteOrderDetails(id);
        }

        public async Task<OrderDetails?> GetOrderDetail(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return await _orderDetailsRepository.GetOrderDetail(id);
        }

        public async Task<IEnumerable<OrderDetails>?> GetListOfOrder_details(int? orderId)
        {
            if (orderId == null)
                throw new ArgumentNullException(nameof(orderId));

            return await _orderDetailsRepository.GetListOfOrder_details(orderId);
        }

        public async Task<OrderDetails?> PostOrderDetails(OrderDetails? orderDetails)
        {
            if (orderDetails == null)
                throw new ArgumentNullException(nameof(orderDetails));

            if (orderDetails.order_id == null)
                throw new ArgumentNullException(nameof(orderDetails.order_id));

            if (string.IsNullOrEmpty(orderDetails.pizza_id))
                throw new ArgumentNullException(nameof(orderDetails.pizza_id));

            if (orderDetails.quantity == null)
                throw new ArgumentNullException(nameof(orderDetails.quantity));

            return await _orderDetailsRepository.PostOrderDetails(orderDetails);
        }

        public async Task<bool> PutOrderDetails(int? id, OrderDetails? orderDetails)
        {
            if (orderDetails == null)
                throw new ArgumentNullException(nameof(orderDetails));

            if (orderDetails.order_id == null)
                throw new ArgumentNullException(nameof(orderDetails.order_id));

            if (string.IsNullOrEmpty(orderDetails.pizza_id))
                throw new ArgumentNullException(nameof(orderDetails.pizza_id));

            if (orderDetails.quantity == null)
                throw new ArgumentNullException(nameof(orderDetails.quantity));

            return await _orderDetailsRepository.PutOrderDetails(id, orderDetails);
        }
    }
}
