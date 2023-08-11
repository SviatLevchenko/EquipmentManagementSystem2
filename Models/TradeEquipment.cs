using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS.Models
{
    public class TradeEquipment
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("Supplier")]
        public int SupplierID { get; set; }

        [ForeignKey("Manufacturer")]
        public int ManufacturerID { get; set; }

        [ForeignKey("EquipmentType")]
        public int EquipmentTypeID { get; set; }

        [ForeignKey("Location")]
        public int LocationID { get; set; }

        public Supplier Supplier { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public EquipmentType EquipmentType { get; set; }
        public Location Location { get; set; }
    }
}