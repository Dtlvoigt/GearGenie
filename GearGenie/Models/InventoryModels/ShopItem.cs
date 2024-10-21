using GearGenie.Models.EquipmentModels;
using System.ComponentModel.DataAnnotations;

namespace GearGenie.Models.InventoryModels
{
    public class ShopItem
    {
        [Key]
        public required int ShopId { get; set; }
        public Shop? Shop { get; set; } = null;

        [Key]
        public required int ItemId { get; set; }
        public Equipment? Item { get; set; } = null;

        public int Quantity { get; set; } = 1;
        public string? ShopSection { get; set; }
    }
}
