using System.ComponentModel.DataAnnotations;

namespace PizzaPlaceApi.Data.DTO
{
    public class OrderRequest
    {
        [Required]
        public int? order_id { get; set; }
        [Required]
        public string? date { get; set;}

        [Required]
        public string? time { get; set; }
    }
}
