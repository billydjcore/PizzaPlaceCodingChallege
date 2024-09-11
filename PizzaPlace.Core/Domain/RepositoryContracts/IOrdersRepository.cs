using PizzaPlace.Core.DTO;
using PizzaPlace.Core.Entities;

namespace PizzaPlace.Core.RepositoryContracts
{
    public interface IOrdersRepository
    {
        /// <summary>
        /// Get all Orders
        /// </summary>
        /// <returns>IEnumerable<Order>.</returns>
        Task<IEnumerable<Order>?> GetOrders();
        /// <summary>
        /// Get Order by id
        /// </summary>
        /// <returns>Order object.</returns>
        Task<Order?> GetOrder(int? id);
        /// <summary>
        /// Update Order object.
        /// </summary>
        /// <returns>true or false after Order update.</returns>
        Task<bool> PutOrder(int? id, Order? updatedOrder);
        /// <summary>
        /// Add pizza object in the list
        /// </summary>
        /// <returns>true or false after pizza is added.</returns>
        Task<bool> PostOrder(OrderRequest? order);
        /// <summary>
        /// Delete Order object in the list
        /// </summary>
        /// <returns>true or false after Order is deleted.</returns>
        Task<bool> DeleteOrder(int? id);      
    }
}
