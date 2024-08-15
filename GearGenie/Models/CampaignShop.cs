using System.ComponentModel.DataAnnotations;

namespace GearGenie.Models
{
    public class CampaignShop
    {
        [Key]
        public required int CampaignId { get; set; }
        public Campaign? Campaign { get; set; } = null;

        [Key]
        public required int ShopId { get; set; }
        public Shop? Shop { get; set; } = null;

        
    }
}
