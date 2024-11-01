using GearGenie.Models.EquipmentModels;
using Microsoft.EntityFrameworkCore;

namespace GearGenie.Data
{
    public class GearContext : DbContext, IGearContext
    {
        public GearContext(DbContextOptions<GearContext> options) : base(options) { }

        //public virtual DbSet<Equipment> Equipment { get; set; }
        //public virtual DbSet<EquipmentCategory> EquipmentCategories { get; set; }
    }
}
