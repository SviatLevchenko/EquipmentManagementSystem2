using System.ComponentModel.DataAnnotations;

namespace EMS.Models
{
    public class Supplier
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}