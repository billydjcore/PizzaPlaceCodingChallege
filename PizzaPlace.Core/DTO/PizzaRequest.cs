using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PizzaPlace.Core.DTO
{
    public class PizzaRequest
    {

        [Required]
        public string pizza_id { get; set; }
        [Required]
        public string pizza_type { get; set; }
        [Required]
        public string size { get; set; }
        [Required]
        public decimal price { get; set; }

    }
}
