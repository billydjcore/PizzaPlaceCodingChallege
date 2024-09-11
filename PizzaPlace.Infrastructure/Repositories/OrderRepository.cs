using Microsoft.EntityFrameworkCore;
using PizzaPlace.Infrastructure.DBContext;
using PizzaPlace.Core.RepositoryContracts;
using PizzaPlace.Core.Entities;
using Newtonsoft.Json;
using System.Net.Http.Json;
using PizzaPlace.Core.DTO;
namespace PizzaPlace.Api.Data
{
    public class OrderRepository : IOrdersRepository
    {
        Uri hostAddress = new Uri("http://localhost:5098//api");
        private readonly HttpClient httpclient;
        
        public OrderRepository(IHttpClientFactory factory)
        {
            httpclient = factory.CreateClient();
            httpclient.BaseAddress = hostAddress;
        }

        public async Task<bool> DeleteOrder(int? id)
        {
            bool isDeleted = false;
            var deleteOrderResult = await httpclient.DeleteAsync(httpclient.BaseAddress + $"/Orders/DeleteOrder/{id}");
            if (deleteOrderResult.IsSuccessStatusCode)
            {
                Console.WriteLine("Deleted successfully");
                isDeleted = true;
            }
            return isDeleted;
        }

        public async Task<Order?> GetOrder(int? id)
        {
            Order foundOrder = null;
            var findOrderResult = await httpclient.GetAsync(httpclient.BaseAddress + $"/Orders/GetOrder/{id}");
            if (findOrderResult.IsSuccessStatusCode)
            {
                string data = findOrderResult.Content.ReadAsStringAsync().Result;
                foundOrder = JsonConvert.DeserializeObject<Order>(data);
            }
            return foundOrder;
        }

        public async Task<IEnumerable<Order>?> GetOrders()
        {
            List<Order> orders = new List<Order>();
            var orderlistResult = await httpclient.GetAsync(httpclient.BaseAddress + "/Orders/GetOrders");
            if (orderlistResult.IsSuccessStatusCode)
            {
                string data = orderlistResult.Content.ReadAsStringAsync().Result;
                orders = JsonConvert.DeserializeObject<List<Order>>(data);
            }
            return orders;
        }

       

        public async Task<bool> PostOrder(OrderRequest? newOrder)
        {
            bool isAdded = false;
            HttpResponseMessage addProductResult = await httpclient.PostAsJsonAsync(httpclient.BaseAddress + "/Orders/AddOrder", newOrder);
            if (addProductResult.IsSuccessStatusCode)
            {
                Console.WriteLine("successfully added");
                isAdded = true;
            }
            return isAdded;
        }

        public async Task<bool> PutOrder(int? id, Order? order)
        {
            bool isUpdated = false;

            var editOrderResult = await httpclient.PutAsJsonAsync(httpclient.BaseAddress + $"/Orders/UpdateOrder/{order?.order_id}", order);
            if (editOrderResult.IsSuccessStatusCode)
            {
                Console.WriteLine("Updated successfully");
                isUpdated = true;
            }
       
            return isUpdated;
        }
    }
}
