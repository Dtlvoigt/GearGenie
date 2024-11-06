using System.ComponentModel.DataAnnotations;

namespace GearGenie.Models.InventoryModels
{
    public class Shop
    {
        [Key]
        public int Id { get; set; }
        public ICollection<ShopItem>? Items { get; set; }
    }
}
