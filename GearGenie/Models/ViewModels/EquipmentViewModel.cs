using GearGenie.Models.EquipmentModels;
using GearGenie.Models.InventoryModels;

namespace GearGenie.Models.ViewModels
{
    public class EquipmentViewModel
    {
        public List<Equipment> Equipment { get; set; }
        public List<PlayerCharacter> PlayerCharacters { get; set; }
        public List<Shop> Shops { get; set; }
    }
}
