using Microsoft.EntityFrameworkCore;
using PizzaPlace.Infrastructure.DBContext;
using PizzaPlace.Core.RepositoryContracts;
using PizzaPlace.Core.Entities;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace PizzaPlace.Api.Data
{
    public class PizzaRepository : IPizzasRepository
    {
        Uri hostAddress = new Uri("http://localhost:5098//api");
        private readonly HttpClient httpclient;
       
        public PizzaRepository(IHttpClientFactory factory)
        {
            httpclient = factory.CreateClient();
            httpclient.BaseAddress = hostAddress;
        }

        public async Task<bool> DeletePizza(int? id)
        {
            bool isDeleted = false;
            var deletePizzaResult = await httpclient.DeleteAsync(httpclient.BaseAddress + $"/Pizzas/DeletePizza/{id}");
            if (deletePizzaResult.IsSuccessStatusCode)
            {
                Console.WriteLine("Deleted successfully");
                isDeleted = true;
            }
            return isDeleted;
        }

        public async Task<Pizza?> GetPizza(int? id)
        {
            Pizza foundPizza = null;
            var findPizzaResult = await httpclient.GetAsync(httpclient.BaseAddress + $"/Pizzas/AddPizza/{id}");
            if (findPizzaResult.IsSuccessStatusCode)
            {
                string data = findPizzaResult.Content.ReadAsStringAsync().Result;
                foundPizza = JsonConvert.DeserializeObject<Pizza>(data);
            }
            return foundPizza;
        }

        public async Task<IEnumerable<Pizza>?> GetPizzas()
        {
            List<Pizza> pizzaz = new List<Pizza>();
            var pizzaslistResult = await httpclient.GetAsync(httpclient.BaseAddress + "/Pizzas/GetPizzas");
            if (pizzaslistResult.IsSuccessStatusCode)
            {
                string data = pizzaslistResult.Content.ReadAsStringAsync().Result;
                pizzaz = JsonConvert.DeserializeObject<List<Pizza>>(data);
            }
            return pizzaz;
        }

        public async Task<Pizza?> PostPizza(Pizza? pizza)
        {
            HttpResponseMessage addPizzaResult = await httpclient.PostAsJsonAsync(httpclient.BaseAddress + "/Pizzas/AddPizza", pizza);
            if (addPizzaResult.IsSuccessStatusCode)
            {
                Console.WriteLine("successfully added");
                return pizza;
            }
            return null;
        }

        public async Task<bool> PutPizza(int? id, Pizza? updatedPizza)
        {
            bool isUpdated = false;

            var editPizzaResult = await httpclient.PutAsJsonAsync(httpclient.BaseAddress + $"/Pizzas/UpdatePizza/{id}", updatedPizza);
            if (editPizzaResult.IsSuccessStatusCode)
            {
                Console.WriteLine("Updated successfully");
                isUpdated = true;
            }

            return isUpdated;
        }

    }
}
