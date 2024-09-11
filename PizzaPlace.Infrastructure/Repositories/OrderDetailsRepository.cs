using Microsoft.EntityFrameworkCore;
using PizzaPlace.Infrastructure.DBContext;
using PizzaPlace.Core.RepositoryContracts;
using PizzaPlace.Core.Entities;
using Newtonsoft.Json;
using System.Net.Http.Json;
namespace PizzaPlace.Api.Data
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        Uri hostAddress = new Uri("http://localhost:5098//api");
        private readonly HttpClient httpclient;
        public OrderDetailsRepository(IHttpClientFactory factory)
        {
            httpclient = factory.CreateClient();
            httpclient.BaseAddress = hostAddress;
        }

        public async Task<bool> DeleteOrderDetails(int? id)
        {
            bool isDeleted = false;
            var deleteOrderDetailResult = await httpclient.DeleteAsync(httpclient.BaseAddress + $"/OrderDetails/DeleteOrderDetails/{id}");
            if (deleteOrderDetailResult.IsSuccessStatusCode)
            {
                Console.WriteLine("Deleted successfully");
                isDeleted = true;
            }
            return isDeleted;
        }

        public async Task<OrderDetails?> GetOrderDetail(int? id)
        {
            OrderDetails foundOrderDetail = null;
            var findOrderDetailResult = await httpclient.GetAsync(httpclient.BaseAddress + $"/OrderDetails/GetOrderDetails/{id}");
            if (findOrderDetailResult.IsSuccessStatusCode)
            {
                string data = findOrderDetailResult.Content.ReadAsStringAsync().Result;
                foundOrderDetail = JsonConvert.DeserializeObject<OrderDetails>(data);
            }
            return foundOrderDetail;
        }

        public async Task<IEnumerable<OrderDetails>?> GetListOfOrder_details(int? orderId)
        {
            List<OrderDetails> ordersDetails = new List<OrderDetails>();
            var orderlistResult = await httpclient.GetAsync(httpclient.BaseAddress + $"/OrderDetails/GetListOfOrderDetails/{orderId}");
            if (orderlistResult.IsSuccessStatusCode)
            {
                string data = orderlistResult.Content.ReadAsStringAsync().Result;
                ordersDetails = JsonConvert.DeserializeObject<List<OrderDetails>>(data);
            }
            return ordersDetails;
        }
        public async Task<OrderDetails?> PostOrderDetails(OrderDetails? orderDetails)
        {
            HttpResponseMessage addOrderDetailResult = await httpclient.PostAsJsonAsync(httpclient.BaseAddress + "/OrderDetails/AddOrderDetails", orderDetails);
            if (addOrderDetailResult.IsSuccessStatusCode)
            {
                Console.WriteLine("successfully added");
                return orderDetails;
            }
            return null;
        }

        public async Task<bool> PutOrderDetails(int? id, OrderDetails? orderDetails)
        {
            bool isUpdated = false;

            var editOrderDetailResult = await httpclient.PutAsJsonAsync(httpclient.BaseAddress + $"/OrderDetails/UpdateOrderDetails/{id}", orderDetails);
            if (editOrderDetailResult.IsSuccessStatusCode)
            {
                Console.WriteLine("Updated successfully");
                isUpdated = true;
            }

            return isUpdated;
        }
    }
}
