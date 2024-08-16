using System.ComponentModel.DataAnnotations;

namespace GearGenie.Models
{
    public enum EquipmentCategory
    {
        Weapon,
        Armor,
        Item
    }

    public enum WeaponCategory
    {

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
        public WeaponCategory? WeaponCategory { get; set; }
        public RangeCategory? RangeCategory { get; set; }
        public string? Description { get; set; }
        public int Weight { get; set; } = 0;

    }

    
}
