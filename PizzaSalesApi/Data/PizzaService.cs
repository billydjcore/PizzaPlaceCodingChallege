using Microsoft.EntityFrameworkCore;
using PizzaPlace.Api.Services;
using PizzaPlaceApi.Data;
using PizzaPlaceApi.Data.Models;

namespace PizzaPlace.Api.Data
{
    public class PizzaService : IPizzasService
    {
        private readonly ApplicationDbContext _context;
        public PizzaService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<bool> DeletePizza(int? id)
        {
            bool isDeleted = false;
            Pizza? foundPizza = _context.pizzas.Find(id);
            if (foundPizza != null)
            {
                _context.pizzas.Remove(foundPizza);
                await _context.SaveChangesAsync();
                isDeleted = true;
            }
            return isDeleted;
        }

        public async Task<Pizza?> GetPizza(int? id)
        {
            return await _context.pizzas.FindAsync(id);
        }

        public async Task<IEnumerable<Pizza>?> Getpizzas()
        {
            return await _context.pizzas.ToListAsync();
        }

        public bool PizzaExists(int? id)
        {
            bool isExist = false;
            Pizza? foundPizza = _context.pizzas.Find(id);
            if (foundPizza != null) 
            {
                isExist = true;
            }
            return isExist;
        }

        public async Task<Pizza?> PostPizza(Pizza? pizza)
        {
            _context.pizzas.Add(pizza);
            await _context.SaveChangesAsync();
            return pizza;
        }

        public async Task<bool> PutPizza(int? id, Pizza? updatedPizza)
        {
            bool isUpdated = false;

            Pizza? foundPizza = _context.pizzas.Find(id);
            if (foundPizza != null)
            {
                _context.Entry(foundPizza).State = EntityState.Modified;
                foundPizza.pizza_id = updatedPizza.pizza_id;
                foundPizza.pizza_type_id = updatedPizza.pizza_type_id;
                foundPizza.size = updatedPizza.size;
                foundPizza.pizza_id = updatedPizza.pizza_id;
                await _context.SaveChangesAsync();
                isUpdated = true;
            }

            return isUpdated;
        }

    }
}
