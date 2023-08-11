using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS.Models
{
    public class ReplaceInfo
    {
        [Key]
        public int ID { get; set; }

        public DateTime DateTime { get; set; }

        [ForeignKey("TradeEquipment")]
        public int EquipmentID { get; set; }

        [ForeignKey("Location")]
        public int LocationFromID { get; set; }

        [ForeignKey("Location")]
        public int LocationToID { get; set; }

        public TradeEquipment TradeEquipment { get; set; }
        public Location LocationFrom { get; set; }
        public Location LocationTo { get; set; }
    }
}