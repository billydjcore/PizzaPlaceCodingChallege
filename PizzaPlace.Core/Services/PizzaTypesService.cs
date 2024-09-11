using PizzaPlace.Core.Entities;
using PizzaPlace.Core.RepositoryContracts;
using PizzaPlace.Core.ServiceContracts;

namespace PizzaPlace.Core.Services
{
    public class PizzaTypesService : IPizzaTypesService
    {
        private readonly IPizzaTypesRepository _iPizzaTypesRepository;
        public PizzaTypesService(IPizzaTypesRepository pizzaTypesRepository) 
        {
            _iPizzaTypesRepository = pizzaTypesRepository;
        }

        public async Task<bool> DeletePizzaType(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(DeletePizzaType));

            return  await _iPizzaTypesRepository.DeletePizzaType(id);
        }

        public async Task<PizzaType?> GetPizzaType(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return await _iPizzaTypesRepository.GetPizzaType(id);
        }

        public async Task<IEnumerable<PizzaType>?> Getpizza_types()
        {
            return await _iPizzaTypesRepository.Getpizza_types();
        }

        public async Task<PizzaType?> PostPizzaType(PizzaType? pizzaType)
        {
            if (pizzaType == null)
                throw new ArgumentNullException(nameof(pizzaType));

            if (string.IsNullOrEmpty(pizzaType.pizza_type_id))
                throw new ArgumentNullException(nameof(pizzaType));

            if (string.IsNullOrEmpty(pizzaType.name))
                throw new ArgumentNullException(nameof(pizzaType));

            if (string.IsNullOrEmpty(pizzaType.category))
                throw new ArgumentNullException(nameof(pizzaType));

            await _iPizzaTypesRepository.PostPizzaType(pizzaType);
            return pizzaType;
        }

        public async Task<bool> PutPizzaType(int? id, PizzaType? updatedPizzaType)
        {           
            if (updatedPizzaType == null)
                throw new ArgumentNullException(nameof(PizzaType));

            if (string.IsNullOrEmpty(updatedPizzaType.pizza_type_id))
                throw new ArgumentNullException(nameof(PizzaType));

            if (string.IsNullOrEmpty(updatedPizzaType.name))
                throw new ArgumentNullException(nameof(PizzaType));

            if (string.IsNullOrEmpty(updatedPizzaType.category))
                throw new ArgumentNullException(nameof(PizzaType));
           
            return await _iPizzaTypesRepository.PutPizzaType(id, updatedPizzaType);
        }
    }
}
