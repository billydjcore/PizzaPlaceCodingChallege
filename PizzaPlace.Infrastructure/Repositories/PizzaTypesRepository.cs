using Microsoft.EntityFrameworkCore;
using PizzaPlace.Infrastructure.DBContext;
using PizzaPlace.Core.RepositoryContracts;
using PizzaPlace.Core.Entities;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace PizzaPlace.Api.Data
{
    public class PizzaTypesRepository : IPizzaTypesRepository
    {
        Uri hostAddress = new Uri("http://localhost:5098//api");
        private readonly HttpClient httpclient;
        public PizzaTypesRepository(IHttpClientFactory factory) 
        {
            httpclient = factory.CreateClient();
            httpclient.BaseAddress = hostAddress;
        }

        public async Task<bool> DeletePizzaType(int? id)
        {
            bool isDeleted = false;
            var deletePizzaTypeResult = await httpclient.DeleteAsync(httpclient.BaseAddress + $"/PizzaTypes/DeletePizzaType/{id}");
            if (deletePizzaTypeResult.IsSuccessStatusCode)
            {
                Console.WriteLine("Deleted successfully");
                isDeleted = true;
            }
            return isDeleted;
        }

        public async Task<PizzaType?> GetPizzaType(int? id)
        {
            PizzaType foundPizzaType = null;
            var findPizzaTypeResult = await httpclient.GetAsync(httpclient.BaseAddress + $"/PizzaTypes/GetPizzaType/{id}");
            if (findPizzaTypeResult.IsSuccessStatusCode)
            {
                string data = findPizzaTypeResult.Content.ReadAsStringAsync().Result;
                foundPizzaType = JsonConvert.DeserializeObject<PizzaType>(data);
            }
            return foundPizzaType;
        }

        public async Task<IEnumerable<PizzaType>?> Getpizza_types()
        {
            List<PizzaType> pizzaTypelist = new List<PizzaType>();
            var pizzaTypelistResult = await httpclient.GetAsync(httpclient.BaseAddress + "/PizzaTypes/GetPizzaTypes");
            if (pizzaTypelistResult.IsSuccessStatusCode)
            {
                string data = pizzaTypelistResult.Content.ReadAsStringAsync().Result;
                pizzaTypelist = JsonConvert.DeserializeObject<List<PizzaType>>(data);
            }
            return pizzaTypelist;
        }

        public async Task<PizzaType?> PostPizzaType(PizzaType? pizzaType)
        {
            HttpResponseMessage addPizzaTypeResult = await httpclient.PostAsJsonAsync(httpclient.BaseAddress + "/PizzaTypes/AddPizzaType", pizzaType);
            if (addPizzaTypeResult.IsSuccessStatusCode)
            {
                Console.WriteLine("successfully added");
                return pizzaType;
            }
            return null;
        }

        public async Task<bool> PutPizzaType(int? id, PizzaType? updatedPizzaType)
        {
            bool isUpdated = false;

            var editPizzaTypeResult = await httpclient.PutAsJsonAsync(httpclient.BaseAddress + $"/PizzaTypes/UpdatePizzaType/{id}", updatedPizzaType);
            if (editPizzaTypeResult.IsSuccessStatusCode)
            {
                Console.WriteLine("Updated successfully");
                isUpdated = true;
            }

            return isUpdated;          
        }
    }
}
