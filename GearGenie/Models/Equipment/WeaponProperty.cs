using System.ComponentModel.DataAnnotations;

namespace GearGenie.Models.Equipment
{
    public class WeaponProperty
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
