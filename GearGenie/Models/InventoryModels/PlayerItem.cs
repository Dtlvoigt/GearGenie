using GearGenie.Models.EquipmentModels;
using System.ComponentModel.DataAnnotations;

namespace GearGenie.Models.InventoryModels
{
    public class PlayerItem
    {
        [Key]
        public required int PlayerCharacterId { get; set; }
        public PlayerCharacter? PlayerCharacter { get; set; } = null;

        [Key]
        public required int ItemId { get; set; }
        public Equipment? Item { get; set; } = null;

        public int Quantity { get; set; } = 1;
    }
}
