using System.ComponentModel.DataAnnotations;

namespace EMS.Models
{
    public class Manufacturer
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}