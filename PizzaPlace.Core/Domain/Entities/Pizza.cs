using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PizzaPlace.Core.Entities
{
    public class Pizza
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int id { get; set; }
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
