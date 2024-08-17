using System.ComponentModel.DataAnnotations;

namespace GearGenie.Models.Equipment
{
    public class EquipmentCategory
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
