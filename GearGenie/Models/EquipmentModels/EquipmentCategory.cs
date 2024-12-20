﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GearGenie.Models.EquipmentModels
{
    public class EquipmentCategory
    {
        [Key]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public required string Name { get; set; }
    }
}
