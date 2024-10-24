﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GearGenie.Models.InventoryModels
{
    public class Campaign
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campaign name is required")]
        public required string Name { get; set; }
        public required int OwnerId { get; set; }
        public string? Admins { get; set; } //option to allow multiple users to manage a campaign

        public ICollection<CampaignShop>? Shops { get; set; }
    }
}
