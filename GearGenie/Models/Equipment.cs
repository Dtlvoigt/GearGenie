using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GearGenie.Models
{
    public class Cost
    {
        public int quantity { get; set; }
        public string? unit { get; set; }

        //convert price to gold currency
        public double ConverToGold(string unit, int amount)
        {
            switch (unit)
            {
                case "cp":
                    return amount * .01;
                case "sp":
                    return amount * .1;
                case "ep":
                    return amount * 2;
                case "gp":
                    return amount;
                case "pp":
                    return amount * 10;
                default:
                    return amount;
            }
        }
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

        [JsonPropertyName("desc")]
        public JsonElement? DescriptionElement { get; set; }
        public string? Description
        {
            get
            {
                if (DescriptionElement.HasValue && DescriptionElement.Value.ValueKind == JsonValueKind.Array)
                {
                    // Extract all strings from the array and join them with a symbol, e.g., "; "
                    return string.Join("; ", DescriptionElement.Value.EnumerateArray().Select(d => d.GetString()));
                }
                else
                {
                    return null;
                }
            }
        }

        [JsonPropertyName("cost")]
        public Cost? CostElement { get; set; }
        public int? CostAmount
        {
            get
            {
                if (CostElement != null)
                {
                    return CostElement.quantity;
                }
                else
                {
                    return null;
                }
            }
        }
        public string? CostType
        {
            get
            {
                if (CostElement != null)
                {
                    return CostElement.unit;
                }
                else
                {
                    return null;
                }
            }
        }
        public double GoldCost
        {
            get
            {
                if (CostElement != null && !String.IsNullOrWhiteSpace(CostType) && CostAmount != null)
                {
                    return CostElement.ConverToGold(CostType, CostAmount.Value);
                }
                else
                {
                    return 0;
                }
            }
        }

        [JsonPropertyName("weight")]
        public decimal Weight { get; set; } = 0;


        /////////////////////
        //weapon properties//
        /////////////////////

        [JsonPropertyName("weapon_category")]
        public string? WeaponCategory { get; set; }

        [JsonPropertyName("weapon_range")]
        public string? WeaponRange { get; set; }

        [JsonPropertyName("category_range")]
        public string? RangeCategory { get; set; }

        [JsonPropertyName("range")]
        public JsonElement? RangeElement { get; set; }
        public int? RangeNormal
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
                    return null;
                }
            }
        }
        public int? RangeLong
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
                    return null;
                }
            }
        }

        [JsonPropertyName("throw_range")]
        public JsonElement? ThrowRangeElement { get; set; }
        public int? ThrowRangeNormal
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
                    return null;
                }
            }
        }
        public int? ThrowRangeLong
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
                    return null;
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

        [JsonPropertyName("special")]
        public JsonElement? SpecialAttributeElement { get; set; }
        public string? SpecialAttribute
        {
            get
            {
                if (SpecialAttributeElement.HasValue && SpecialAttributeElement.Value.ValueKind == JsonValueKind.Array)
                {
                    // Extract all strings from the array and join them with a symbol, e.g., "; "
                    return string.Join("; ", SpecialAttributeElement.Value.EnumerateArray().Select(s => s.GetString()));
                }
                else
                {
                    return null;
                }
            }
        }

        public ICollection<EquipmentWeaponProperty>? WeaponProperties { get; set; }


        ////////////////////
        //armor properties//
        ////////////////////

        [JsonPropertyName("armor_category")]
        public string? ArmorCategory { get; set; }

        [JsonPropertyName("armor_class")]
        public JsonElement? ArmorClassElement { get; set; }
        public int? ArmorClass
        {
            get
            {
                //set property if json element is present
                if (ArmorClassElement.HasValue && ArmorClassElement.Value.TryGetProperty("base", out JsonElement armorClassElement))
                {
                    return armorClassElement.GetInt32();
                }
                else
                {
                    return null;
                }
            }
        }
        public bool? DexBonus
        {
            get
            {
                //set property if json element is present
                if (ArmorClassElement.HasValue && ArmorClassElement.Value.TryGetProperty("dex_bonus", out JsonElement dexBonusElement))
                {
                    return dexBonusElement.GetBoolean();
                }
                else
                {
                    return null;
                }
            }
        }
        public int? MaxDexBonus
        {
            get
            {
                //set property if json element is present
                if (ArmorClassElement.HasValue && ArmorClassElement.Value.TryGetProperty("max_bonus", out JsonElement maxDexBonusElement))
                {
                    return maxDexBonusElement.GetInt32();
                }
                else
                {
                    return null;
                }
            }
        }

        [JsonPropertyName("str_minimum")]
        public int? StrengthMinimum { get; set; }

        [JsonPropertyName("stealth_disadvantage")]
        public bool? StealthDisadvantage { get; set; }


        ///////////////////
        //gear properties//
        ///////////////////

        [JsonPropertyName("gear_category")]
        public JsonElement? GearCategoryElement { get; set; }
        public string? GearCategory
        {
            get
            {
                //set property if json element is present
                if (GearCategoryElement.HasValue && GearCategoryElement.Value.TryGetProperty("name", out JsonElement gearCategoryElement))
                {
                    return gearCategoryElement.GetString();
                }

                //return null if this json element is missing
                return null;
            }
        }
    }
}
