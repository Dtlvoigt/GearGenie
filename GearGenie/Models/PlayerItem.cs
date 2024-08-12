using System.ComponentModel.DataAnnotations;

namespace GearGenie.Models
{
    public class PlayerItem
    {
        [Key]
        public int PlayerID { get; set; }
        [Key]
        public int ItemID { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
