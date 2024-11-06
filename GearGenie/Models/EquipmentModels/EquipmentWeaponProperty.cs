using System.ComponentModel.DataAnnotations;

namespace GearGenie.Models.EquipmentModels
{
    public class EquipmentWeaponProperty
    {
        public required int EquipmentId { get; set; }
        public Equipment? Equipment { get; set; } = null;
        public required int WeaponPropertyId { get; set; }
        public WeaponProperty? WeaponProperty { get; set; } = null;
    }
}
