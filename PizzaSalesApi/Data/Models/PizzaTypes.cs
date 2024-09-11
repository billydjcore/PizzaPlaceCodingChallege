using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaPlaceApi.Data.Models
{
    public class PizzaType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Key]
        public string pizza_type_id { get; set; }
        [Required]
        public string name { get; set; }
       
        [Required]
        public string category { get; set; }

        [Required]
        public string ingredients { get; set; }
    }
}
