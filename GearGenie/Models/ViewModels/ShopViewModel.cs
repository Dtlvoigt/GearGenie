using GearGenie.Models.InventoryModels;

namespace GearGenie.Models.ViewModels
{
    public class ShopViewModel
    {
        public Shop Shop { get; set; }
        public List<Campaign> Campaigns { get; set; }
        public List<PlayerCharacter> PlayerCharacters { get; set; }
        public List<Shop> Shops { get; set; }
    }
}
