using PizzaPlace.Core.Entities;
namespace PizzaPlace.Core.RepositoryContracts
{
    public interface IPizzaTypesRepository
    {
        /// <summary>
        /// Get all pizza types.
        /// </summary>
        /// <returns>IEnumerable<PizzaType>.</returns>
        Task<IEnumerable<PizzaType>?> Getpizza_types();
        /// <summary>
        /// Get pizza types by id
        /// </summary>
        /// <returns>PizzaType object.</returns>
        Task<PizzaType?> GetPizzaType(int? id);
        /// <summary>
        /// Update pizza_type object.
        /// </summary>
        /// <returns>true or false after pizza_type update.</returns>
        Task<bool> PutPizzaType(int? id, PizzaType? updatedPizzaType);
        /// <summary>
        /// Add pizza_type object in the list
        /// </summary>
        /// <returns>true or false after pizza_type is added.</returns>
        Task<PizzaType?> PostPizzaType(PizzaType? pizzaType);
        /// <summary>
        /// Delete pizza_type object in the list
        /// </summary>
        /// <returns>true or false after pizza_type is deleted.</returns>
        Task<bool> DeletePizzaType(int? id);   
    }
}
