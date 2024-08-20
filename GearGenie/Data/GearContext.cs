using Microsoft.EntityFrameworkCore;

namespace GearGenie.Data
{
    public class GearContext : DbContext, IGearContext
    {
        public GearContext(DbContextOptions<GearContext> options) : base(options) { }

        //public virtual DbSet<>
    }
}
