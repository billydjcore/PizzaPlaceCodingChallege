using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaPlace.Core.Entities
{
    public class PizzaType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int id { get; set; }
        [Required]
        public string pizza_type_id { get; set; }
        [Required]
        public string name { get; set; }
       
        [Required]
        public string category { get; set; }

        [Required]
        public string ingredients { get; set; }
    }
}
