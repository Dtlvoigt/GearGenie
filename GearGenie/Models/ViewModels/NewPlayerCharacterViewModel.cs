using GearGenie.Models.InventoryModels;

namespace GearGenie.Models.ViewModels
{
    public class NewPlayerCharacterViewModel
    {
        public PlayerCharacter PlayerCharacter { get; set; }
        public Campaign Campaign { get; set; }
        public List<PlayerCharacter> PlayerCharacters { get; set; }
        public List<Campaign> Campaigns { get; set; }
    }
}
