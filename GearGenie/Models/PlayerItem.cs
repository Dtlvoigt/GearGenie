using System.ComponentModel.DataAnnotations;

namespace GearGenie.Models
{
    public class PlayerItem
    {
        [Key]
        public required int PlayerId { get; set; }
        [Key]
        public required int ItemId { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
