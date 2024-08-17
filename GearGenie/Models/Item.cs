using GearGenie.Models.Equipment;
using System.ComponentModel.DataAnnotations;

namespace GearGenie.Models
{
    public enum DamageType
    {
        Bludgeoning,
        Piercing,
        Slashing
    }
    public enum RangeCategory
    {
        Melee,
        Ranged
    }

    public class Item
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required EquipmentCategory EquipmentCategory { get; set; }
        public WeaponProperty? WeaponProperty { get; set; }
        public RangeCategory? RangeCategory { get; set; }
        public string? Description { get; set; }
        public int Weight { get; set; } = 0;

    }

    
}
