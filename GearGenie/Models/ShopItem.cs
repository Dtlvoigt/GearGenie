using System.ComponentModel.DataAnnotations;

namespace GearGenie.Models
{
    public class ShopItem
    {
        [Key]
        public required Shop Shop { get; set; }
        [Key]
        public required Item Item { get; set; }
        public int Quantity { get; set; } = 1;
        public string? ShopSection { get; set; }
    }
}
