using System.ComponentModel.DataAnnotations;

namespace EMS.Models
{
    public class Location
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}