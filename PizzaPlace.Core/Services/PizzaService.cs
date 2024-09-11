using PizzaPlace.Core.Entities;
using PizzaPlace.Core.RepositoryContracts;
using PizzaPlace.Core.ServiceContracts;


namespace PizzaPlace.Core.Services
{
    public class PizzaService : IPizzasService
    {
        private readonly IPizzasRepository _iPizzasRepository;
        public PizzaService(IPizzasRepository pizzasRepository)
        {
            _iPizzasRepository = pizzasRepository;
        }

        public async Task<bool> DeletePizza(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return await _iPizzasRepository.DeletePizza(id);
        }

        public async Task<Pizza?> GetPizza(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return await _iPizzasRepository.GetPizza(id);
        }

        public async Task<IEnumerable<Pizza>?> Getpizzas()
        {
            return await _iPizzasRepository.GetPizzas();
        }

        public async Task<Pizza?> PostPizza(Pizza? pizza)
        {
            if (pizza == null)
                throw new ArgumentNullException(nameof(pizza));

            if (string.IsNullOrEmpty(pizza.pizza_id))
                throw new ArgumentNullException(nameof(pizza));

            if (string.IsNullOrEmpty(pizza.pizza_id))
                throw new ArgumentNullException(nameof(pizza));

            if (string.IsNullOrEmpty(pizza.size))
                throw new ArgumentNullException(nameof(pizza));

            await _iPizzasRepository.PostPizza(pizza);
            return pizza;
        }

        public async Task<bool> PutPizza(int? id, Pizza? updatedPizza)
        {
            if (updatedPizza == null)
                throw new ArgumentNullException(nameof(updatedPizza));

            if (string.IsNullOrEmpty(updatedPizza.pizza_type_id))
                throw new ArgumentNullException(nameof(updatedPizza));

            if (string.IsNullOrEmpty(updatedPizza.pizza_id))
                throw new ArgumentNullException(nameof(updatedPizza));

            if (string.IsNullOrEmpty(updatedPizza.size))
                throw new ArgumentNullException(nameof(updatedPizza));

           return await _iPizzasRepository.PutPizza(id, updatedPizza);
        }

    }
}
