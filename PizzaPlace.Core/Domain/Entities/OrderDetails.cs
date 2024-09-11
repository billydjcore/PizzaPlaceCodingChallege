using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaPlace.Core.Entities
{
    public class OrderDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int id { get; set; }
        [Required]
        public int? order_details_id { get; set; }
        [Required]
        public int? order_id { get; set; }
        [Required]
        public string? pizza_id { get; set; }
        [Required]
        public int? quantity { get; set; }
    }
}
