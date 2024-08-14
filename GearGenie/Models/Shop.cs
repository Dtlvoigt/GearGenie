using System.ComponentModel.DataAnnotations;

namespace GearGenie.Models
{
    public class Shop
    {
        [Key]
        public int Id { get; set; }

        public ICollection<ShopItem>? Items { get; set; }
    }
}
