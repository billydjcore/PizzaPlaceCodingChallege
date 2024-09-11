using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PizzaPlaceApi.Data.DTO
{
    public class PizzaRequest
    {

        [Required]
        public string pizza_id { get; set; }
        [Required]
        public string pizza_type_id { get; set; }
        [Required]
        public string size { get; set; }
        [Required]
        public decimal price { get; set; }

    }
}
