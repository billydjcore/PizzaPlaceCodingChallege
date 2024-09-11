using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaPlaceApi.Data.Models
{
    public class Order
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int? order_id { get; set; }

        [Required]
        public string? date { get; set; }

        [Required]
        public string? time { get; set; }
    }
}
