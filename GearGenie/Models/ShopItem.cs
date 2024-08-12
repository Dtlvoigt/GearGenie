using System.ComponentModel.DataAnnotations;

namespace GearGenie.Models
{
    public class ShopItem
    {
        [Key]
        public int ShopID { get; set; }
        [Key]
        public int ItemID { get; set; }
        public int Quantity { get; set; } = 1;
        public string? ShopSection { get; set; }
    }
}
