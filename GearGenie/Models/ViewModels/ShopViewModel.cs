using GearGenie.Models.InventoryModels;

namespace GearGenie.Models.ViewModels
{
    public class ShopViewModel
    {
        public List<Campaign> Campaign { get; set; }
        public List<PlayerCharacter> PlayerCharacters { get; set; }
        Shop Shop { get; set; }
        public List<Shop> Shops { get; set; }
    }
}
