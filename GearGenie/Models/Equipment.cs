using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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

    public class Equipment
    {
        [Key]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public required string Name { get; set; }
        [JsonPropertyName("equipment_category")]
        public required EquipmentCategory EquipmentCategory { get; set; }
        public string? Description { get; set; }
        [JsonPropertyName("cost")]
        public int Cost { get; set; } = 0;
        [JsonPropertyName("weight")]
        public int Weight { get; set; } = 0;


        //weapon properties
        [JsonPropertyName("weapon_category")]
        public string? WeaponCategory { get; set; }
        [JsonPropertyName("weapon_range")]
        public string? WeaponRange { get; set; }
        [JsonPropertyName("category_range")]
        public string? RangeCategory { get; set; }
        public int RangeNormal { get; set; } = 0;
        public int RangeLong { get; set; } = 0;
        public int ThrowRangeNormal { get; set; } = 0;
        public int ThrowRangeLong { get; set; } = 0;
        [JsonPropertyName("damage_dice")]
        public string? DamageDice { get; set; }
        [JsonPropertyName("damage_type")]
        public string? DamageType {  get; set; }
        [JsonPropertyName("special")]
        public string? Special { get; set; }
        public ICollection<EquipmentWeaponProperty>? WeaponProperties { get; set; }


        //armor properties
        [JsonPropertyName("armor_category")]
        public string? ArmorCategory { get; set; }
        [JsonPropertyName("base")]
        public int ArmorClass { get; set; } = 0;
        [JsonPropertyName("dex_bonus")]
        public bool? DexBonus { get; set; }
        [JsonPropertyName("str_minimum")]
        public int StrengthMinimum {  get; set; } = 0;
        [JsonPropertyName("stealth_disadvantage")]
        public bool? StealthDisadvantage { get; set; }


        //adventuring gear properties
        [JsonPropertyName("gear_category")]
        public string? GearCategory {  get; set; }        
    }

    
}
