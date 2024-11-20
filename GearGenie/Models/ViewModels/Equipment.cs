using GearGenie.Models.InventoryModels;

namespace GearGenie.Models.ViewModels
{
    public class Equipment
    {
        public Equipment equipment { get; set; }
        public List<Campaign> Campaigns { get; set; }
        public List<PlayerCharacter> PlayerCharacters { get; set; }
        public List<Shop> Shops { get; set; }
    }
}
