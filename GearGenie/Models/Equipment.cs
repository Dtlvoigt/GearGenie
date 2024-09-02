using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
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

        [JsonPropertyName("url")]
        public string? URL { get; set; }

        [JsonPropertyName("equipment_category")]
        public JsonElement EquipmentCategoryElement { get; set; }
        public string? EquipmentCategory => EquipmentCategoryElement.GetProperty("name").GetString();

        //[JsonPropertyName("desc")]
        public string? Description { get; set; }

        public int MoneyAmount { get; set; }

        public string? MoneyType { get; set; }

        [JsonPropertyName("cost")]
        public Cost? CostElement { get; set; }
        public float Cost { get; set; } = 0;
        //public Cost Cost
        //{
        //    get => new Cost { quantity = MoneyAmount, unit = MoneyType };
        //    set
        //    {
        //        MoneyAmount = value.quantity;
        //        MoneyType = value.unit;
        //    }
        //}

        [JsonPropertyName("weight")]
        public decimal Weight { get; set; } = 0;


        //weapon properties
        [JsonPropertyName("weapon_category")]
        public string? WeaponCategory { get; set; }

        [JsonPropertyName("weapon_range")]
        public string? WeaponRange { get; set; }

        [JsonPropertyName("category_range")]
        public string? RangeCategory { get; set; }

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
                else
                {
                    return 0;
                }
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
                else
                {
                    return 0;
                }
            }
        }

        [JsonPropertyName("throw_range")]
        public JsonElement? ThrowRangeElement { get; set; }
        public int ThrowRangeNormal
        {
            get
            {
                //set property if json element is present
                if (ThrowRangeElement.HasValue && ThrowRangeElement.Value.TryGetProperty("normal", out JsonElement throwRangeNormalElement))
                {
                    return throwRangeNormalElement.GetInt32();
                }
                else
                {
                    return 0;
                }
            }
        }
        public int ThrowRangeLong
        {
            get
            {
                //set property if json element is present
                if (ThrowRangeElement.HasValue && ThrowRangeElement.Value.TryGetProperty("long", out JsonElement throwRangeLongElement))
                {
                    return throwRangeLongElement.GetInt32();
                }
                else
                {
                    return 0;
                }
            }
        }

        [JsonPropertyName("damage")]
        public JsonElement? DamageElement { get; set; }
        public string? DamageDice
        {
            get
            {
                //set property if json element is present
                if (DamageElement.HasValue && DamageElement.Value.TryGetProperty("damage_dice", out JsonElement damageDiceElement))
                {
                    return damageDiceElement.GetString();
                }
                else
                {
                    return null;
                }
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
                else
                {
                    return null;
                }
            }
        }

        [JsonPropertyName("two_handed_damage")]
        public JsonElement? TwoHandedElement { get; set; }
        public string? TwoHandedDamageDice
        {
            get
            {
                //set property if json element is present
                if (TwoHandedElement.HasValue && TwoHandedElement.Value.TryGetProperty("damage_dice", out JsonElement damageDiceElement))
                {
                    return damageDiceElement.GetString();
                }
                else
                {
                    return null;
                }
            }
        }
        public string? TwoHandedDamageType
        {
            get
            {
                //check nested object for damage type property
                if (TwoHandedElement.HasValue &&
                    TwoHandedElement.Value.TryGetProperty("damage_type", out JsonElement damageTypeElement) &&
                    damageTypeElement.TryGetProperty("name", out JsonElement damageTypeName))
                {
                    return damageTypeName.GetString();
                }
                else
                {
                    return null;
                }
            }
        }

        //[JsonPropertyName("special")]
        public string? Special { get; set; }

        public ICollection<EquipmentWeaponProperty>? WeaponProperties { get; set; }


        //armor properties
        [JsonPropertyName("armor_category")]
        public string? ArmorCategory { get; set; }

        //[JsonPropertyName("base")]
        public int ArmorClass { get; set; } = 0;

        [JsonPropertyName("dex_bonus")]
        public bool? DexBonus { get; set; }

        [JsonPropertyName("str_minimum")]
        public int StrengthMinimum { get; set; } = 0;

        [JsonPropertyName("stealth_disadvantage")]
        public bool? StealthDisadvantage { get; set; }


        //gear properties
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
    }
}
