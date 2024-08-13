using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GearGenie.Models
{
    public class Campaign
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campaign name is required")]
        public string? Name { get; set; }
        public int OwnerId { get; set; }
        public string? Admins { get; set; } //option to allow multiple users to manage a campaign
    }
}
