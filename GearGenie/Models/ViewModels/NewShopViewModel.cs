using GearGenie.Models.EquipmentModels;
using GearGenie.Models.InventoryModels;

namespace GearGenie.Models.ViewModels
{
    public class NewShopViewModel
    {
        public Shop NewShop { get; set; }
        public List<Campaign> Campaigns { get; set; }
        public List<Equipment> Equipment { get; set; }
        public List<Shop> Shops { get; set; }
    }
}
