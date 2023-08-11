using System.ComponentModel.DataAnnotations;

namespace EMS.Models
{
    public class EquipmentType
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}