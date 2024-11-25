using GearGenie.Models.InventoryModels;

namespace GearGenie.Models.ViewModels
{
    public class ProfileViewModel
    {
        public List<Campaign> Campaigns { get; set; }
        public List<PlayerCharacter> PlayerCharacters { get; set; }
        public List<Shop> Shops { get; set; }
    }
}
