﻿using System.ComponentModel.DataAnnotations;

namespace GearGenie.Models
{
    public class ShopItem
    {
        [Key]
        public required int ShopId { get; set; }
        [Key]
        public required int ItemId { get; set; }
        public int Quantity { get; set; } = 1;
        public string? ShopSection { get; set; }
    }
}
