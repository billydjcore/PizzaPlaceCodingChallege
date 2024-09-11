using Microsoft.EntityFrameworkCore;
using PizzaPlace.Api.Services;
using PizzaPlaceApi.Data;
using PizzaPlaceApi.Data.Models;

namespace PizzaPlace.Api.Data
{
    public class PizzaTypesService : IPizzaTypesService
    {
        private readonly ApplicationDbContext _context;
        public PizzaTypesService(ApplicationDbContext dbContext) 
        {
            _context = dbContext;
        }

        public async Task<bool> DeletePizzaType(int? id)
        {
            bool isDeleted = false;
            PizzaType? foundPizzaType = _context.pizza_types.Find(id);
            if (foundPizzaType != null)
            {
                _context.pizza_types.Remove(foundPizzaType);
                await _context.SaveChangesAsync();
                isDeleted = true;
            }
            return isDeleted;
        }

        public async Task<PizzaType?> GetPizzaType(int? id)
        {
            return await _context.pizza_types.FindAsync(id);
        }

        public async Task<IEnumerable<PizzaType>?> Getpizza_types()
        {
            return await _context.pizza_types.ToListAsync();
        }

        public bool PizzaTypeExists(int? id)
        {
            bool isExist = false;
            PizzaType? foundPizzaType = _context.pizza_types.Find(id);
            if (foundPizzaType != null)
            {
                isExist = true;
            }
            return isExist;
        }

        public async Task<PizzaType?> PostPizzaType(PizzaType? pizzaType)
        {
            _context.pizza_types.Add(pizzaType);
            await _context.SaveChangesAsync();
            return pizzaType;
        }

        public async Task<bool> PutPizzaType(int? id, PizzaType? updatedPizzaType)
        {
            bool isUpdated = false;

            PizzaType? foundPizzaType = _context.pizza_types.Find(id);
            if (foundPizzaType != null)
            {
                _context.Entry(foundPizzaType).State = EntityState.Modified;
                foundPizzaType.pizza_type_id = updatedPizzaType.pizza_type_id;
                foundPizzaType.category = updatedPizzaType.category;
                foundPizzaType.ingredients = updatedPizzaType.ingredients;
                foundPizzaType.name = updatedPizzaType.name;
                await _context.SaveChangesAsync();
                isUpdated = true;
            }

            return isUpdated;
        }
    }
}
