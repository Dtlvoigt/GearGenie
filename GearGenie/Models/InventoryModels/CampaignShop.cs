using System.ComponentModel.DataAnnotations;

namespace GearGenie.Models.InventoryModels
{
    public class CampaignShop
    {
        public required int CampaignId { get; set; }
        public Campaign? Campaign { get; set; } = null;
        public required int ShopId { get; set; }
        public Shop? Shop { get; set; } = null;


    }
}
