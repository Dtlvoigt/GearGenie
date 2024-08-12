using Microsoft.EntityFrameworkCore;

namespace GearGenie.Data
{
    public class RPGInventoryDbContext : DbContext, IRPGInventoryDbContext
    {
        public RPGInventoryDbContext(DbContextOptions<RPGInventoryDbContext> options) : base(options) { }
    }
}
