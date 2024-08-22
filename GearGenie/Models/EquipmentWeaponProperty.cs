using System.ComponentModel.DataAnnotations;

namespace GearGenie.Models
{
    public class EquipmentWeaponProperty
    {
        [Key]
        public required int EquipmentId { get; set; }
        public Equipment? Equipment { get; set; } = null;

        [Key]
        public required int WeaponPropertyId { get; set; }
        public WeaponProperty? WeaponProperty { get; set; } = null;
    }
}
