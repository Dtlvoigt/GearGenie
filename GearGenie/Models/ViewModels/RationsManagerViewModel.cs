using GearGenie.Models.InventoryModels;

namespace GearGenie.Models.ViewModels
{
    public class RationsManagerViewModel
    {
        public Campaign Campaign { get; set; }
        public List<PlayerCharacter> PlayerCharacters { get; set; }
    }
}
