using GearGenie.Models.InventoryModels;

namespace GearGenie.Models.ViewModels
{
    public class HomeViewModel
    {
        public List<Campaign> Campaigns { get; set; }
        public List<PlayerCharacter> PlayerCharacters { get; set; }
        public bool UserAuthorized { get; set; } = false;
    }
}
