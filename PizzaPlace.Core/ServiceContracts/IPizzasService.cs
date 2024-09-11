using PizzaPlace.Core.Entities;
namespace PizzaPlace.Core.ServiceContracts
{
    public interface IPizzasService
    {
        /// <summary>
        /// Get all pizza
        /// </summary>
        /// <returns>IEnumerable<Pizza>.</returns>
        Task<IEnumerable<Pizza>?> Getpizzas();
        /// <summary>
        /// Get pizza by id
        /// </summary>
        /// <returns>Pizza object.</returns>
        Task<Pizza?> GetPizza(int? id);
        /// <summary>
        /// Update pizza object.
        /// </summary>
        /// <returns>true or false after pizza update.</returns>
        Task<bool> PutPizza(int? id, Pizza? updatedPizza);
        /// <summary>
        /// Add pizza object in the list
        /// </summary>
        /// <returns>true or false after pizza is added.</returns>
        Task<Pizza?> PostPizza(Pizza? pizza);
        /// <summary>
        /// Delete pizza object in the list
        /// </summary>
        /// <returns>true or false after pizza is deleted.</returns>
        Task<bool> DeletePizza(int? id);      
    }
}
