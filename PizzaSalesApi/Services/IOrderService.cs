using Microsoft.AspNetCore.Mvc;
using PizzaPlaceApi.Data.Models;

namespace PizzaPlace.Api.Services
{
    public interface IOrderService
    {
        /// <summary>
        /// Get all Orders
        /// </summary>
        /// <returns>IEnumerable<Order>.</returns>
        Task<IEnumerable<Order>?> Getorders();
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
        Task<Order?> PostOrder(Order? order);
        /// <summary>
        /// Delete Order object in the list
        /// </summary>
        /// <returns>true or false after Order is deleted.</returns>
        Task<bool> DeleteOrder(int? id);
        /// <summary>
        /// check Order already exist in the list
        /// </summary>
        /// <returns>true or false if Order object already exist.</returns>
        bool OrderExists(int? id);
    }
}
