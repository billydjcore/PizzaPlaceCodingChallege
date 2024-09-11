using PizzaPlace.Core.Entities;

namespace PizzaPlace.Core.RepositoryContracts
{
    public interface IOrderDetailsRepository
    {
        /// <summary>
        /// Get all OrderDetails.
        /// </summary>
        /// <returns>IEnumerable<OrderDetails>.</returns>
        Task<IEnumerable<OrderDetails>?> GetListOfOrder_details(int? orderId);
        /// <summary>
        /// Get OrderDetails by id
        /// </summary>
        /// <returns>OrderDetails object.</returns>
        Task<OrderDetails?> GetOrderDetail(int? id);
        /// <summary>
        /// Update OrderDetails object.
        /// </summary>
        /// <returns>true or false after OrderDetails update.</returns>
        Task<bool> PutOrderDetails(int? id, OrderDetails? updatedOrderDetails);
        /// <summary>
        /// Add OrderDetails object in the list
        /// </summary>
        /// <returns>true or false after OrderDetails is added.</returns>
        Task<OrderDetails?> PostOrderDetails(OrderDetails? orderDetails);
        /// <summary>
        /// Delete OrderDetails object in the list
        /// </summary>
        /// <returns>true or false after OrderDetails is deleted.</returns>
        Task<bool> DeleteOrderDetails(int? id);       
    }
}
