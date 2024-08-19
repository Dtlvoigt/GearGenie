using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GearGenie.Models.EquipmentTypes
{
    public class WeaponProperty
    {
        [Key]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public required string Name { get; set; }
        [JsonPropertyName("desc")]
        public string? Description { get; set; }
    }
}
