using GearGenie.Models.EquipmentModels;
using GearGenie.Models.InventoryModels;

namespace GearGenie.Models.ViewModels
{
    public class PlayerInventoryViewModel
    {
        public PlayerCharacter PlayerCharacter {  get; set; }
        public Equipment Equipment { get; set; }
    }
}
