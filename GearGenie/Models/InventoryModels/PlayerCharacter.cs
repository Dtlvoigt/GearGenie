using System.ComponentModel.DataAnnotations;

namespace GearGenie.Models.InventoryModels
{
    public class PlayerCharacter
    {
        [Key]
        public int Id { get; set; }
        public required int CampaignId { get; set; }
        public int? OwnerId { get; set; }
        public ICollection<PlayerItem>? Items { get; set; }
    }
}
