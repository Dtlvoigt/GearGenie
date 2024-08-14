using System.ComponentModel.DataAnnotations;

namespace GearGenie.Models
{
    public class CampaignShop
    {
        [Key]
        public required int CampaignId { get; set; }
        [Key]
        public required int ShopId { get; set; }
    }
}
