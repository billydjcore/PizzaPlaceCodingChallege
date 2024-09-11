using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaPlaceApi.Data.DTO
{
    public class OrderDetailsRequest
    {
        [Required]
        public int? order_id { get; set; }
        [Required]
        public int? order_detail_id { get; set; }
        [Required]
        public string? pizza_id { get; set; }
        [Required]
        public int? quantity { get; set; }
    }
}
