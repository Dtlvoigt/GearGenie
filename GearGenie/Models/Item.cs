using System.ComponentModel.DataAnnotations;

namespace GearGenie.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Category { get; set; }
        public string? Description { get; set; }
        public int Weight { get; set; } = 0;

    }
}
