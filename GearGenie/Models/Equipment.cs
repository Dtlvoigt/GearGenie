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

    public class Cost
    {
        public int quantity { get; set; }
        public string? unit { get; set; }
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
        //[JsonPropertyName("damage_dice")]
        //public string? DamageDice { get; set; }
        //[JsonPropertyName("damage_type")]
        //public string? DamageType { get; set; }
        //[JsonPropertyName("special")]
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


        //nested json elements
        [JsonPropertyName("equipment_category")]
        public JsonElement EquipmentCategoryElement { get; set; }
        public string? EquipmentCategory => EquipmentCategoryElement.GetProperty("name").GetString();

        [JsonPropertyName("damage")]
        public JsonElement? DamageElement {  get; set; }
        public string? DamageDice
        {
            get
            {
                //set property if json element is present
                if (DamageElement.HasValue && DamageElement.Value.TryGetProperty("damage_dice", out JsonElement damageDiceElement))
                {
                    return damageDiceElement.GetString();
                }

                //return null if this json element is missing
                return null;
            }
        }
        public string? DamageType
        {
            get
            {
                //check nested object for damage type property
                if (DamageElement.HasValue && 
                    DamageElement.Value.TryGetProperty("damage_type", out JsonElement damageTypeElement) &&
                    damageTypeElement.TryGetProperty("name", out JsonElement damageTypeName)) 
                {
                    return damageTypeName.GetString();
                }
                //return null if this json element is missing
                return null;
            }
        }

        [JsonPropertyName("range")]
        public JsonElement? RangeElement { get; set; }
        public int RangeNormal
        {
            get
            {
                //set property if json element is present
                if (RangeElement.HasValue && RangeElement.Value.TryGetProperty("normal", out JsonElement rangeNormalElement))
                {
                    return rangeNormalElement.GetInt32();
                }

                //return null if this json element is missing
                return 0;
            }
        }
        public int RangeLong
        {
            get
            {
                //set property if json element is present
                if (RangeElement.HasValue && RangeElement.Value.TryGetProperty("long", out JsonElement rangeLongElement))
                {
                    return rangeLongElement.GetInt32();
                }

                //return null if this json element is missing
                return 0;
            }
        }

        [JsonPropertyName("gear_category")]
        public JsonElement? GearCategoryElement { get; set; }
        public string? GearCategory
        {
            get
            {
                //set property if json element is present
                if(GearCategoryElement.HasValue && GearCategoryElement.Value.TryGetProperty("name", out JsonElement gearCategoryElement))
                {
                    return gearCategoryElement.GetString();
                }

                //return null if this json element is missing
                return null;
            }
        }
        //public string? GearCategory => GearCategoryElement.GetProperty("name").GetString();
    }

    
}
