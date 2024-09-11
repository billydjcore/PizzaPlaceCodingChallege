using System.ComponentModel.DataAnnotations;

namespace PizzaPlace.Core.DTO
{
    public class OrderRequest
    {
        [Required]
        public string? date { get; set; }

        [Required]
        public string? time { get; set; }
    }
}
