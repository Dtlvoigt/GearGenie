using System.ComponentModel.DataAnnotations;

namespace GearGenie.Models
{
    public class PlayerItem
    {
        [Key]
        public required PlayerCharacter Character { get; set; }
        [Key]
        public required Item Item { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
