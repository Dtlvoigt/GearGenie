using System.ComponentModel.DataAnnotations;

namespace GearGenie.Models
{
    public class CampaignShop
    {
        [Key]
        public required Campaign Campaign { get; set; }
        [Key]
        public required Shop Shop { get; set; }
    }
}
