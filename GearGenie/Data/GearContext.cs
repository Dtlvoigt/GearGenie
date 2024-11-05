using GearGenie.Models.EquipmentModels;
using GearGenie.Models.InventoryModels;
using Microsoft.EntityFrameworkCore;

namespace GearGenie.Data
{
    public class GearContext : DbContext, IGearContext
    {
        public GearContext(DbContextOptions<GearContext> options) : base(options) { }

        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<EquipmentCategory> Categories { get; set; }
        public virtual DbSet<WeaponProperty> WeaponProperties { get; set; }
        public virtual DbSet<EquipmentWeaponProperty> EquipmentWeaponProperties { get; set; }
        public virtual DbSet<PackContent> PackContents { get; set; }
        public virtual DbSet<PlayerCharacter> PlayerCharacters { get; set; }
        public virtual DbSet<PlayerItem> PlayerItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<Equipment>();
            modelBuilder.Ignore<EquipmentCategory>();
            modelBuilder.Ignore<EquipmentVariant>();
            modelBuilder.Ignore<EquipmentWeaponProperty>();
            modelBuilder.Ignore<PackContent>();
            modelBuilder.Ignore<WeaponProperty>();

            //name values are unique so that duplicate records don't get inserted
            modelBuilder.Entity<Equipment>()
                .HasIndex(e => e.Name)
                .IsUnique();

            modelBuilder.Entity<EquipmentCategory>()
                .HasIndex(e => e.Name)
                .IsUnique();

            modelBuilder.Entity<WeaponProperty>()
                .HasIndex(e => e.Name)
                .IsUnique();

            //define the foreign key for magic item variants
            modelBuilder.Entity<Equipment>()
                .HasMany(e => e.Variants)
                .WithOne(e => e.ParentEquipment)
                .HasForeignKey(e => e.ParentEquipmentId)
                .OnDelete(DeleteBehavior.Restrict);

            //define the foreign keys for EquipmentWeaponProperties
            modelBuilder.Entity<Equipment>()
                .HasMany(e => e.WeaponProperties)
                .WithMany()
                .UsingEntity<EquipmentWeaponProperty>(
                    ewp => ewp.HasOne(ewp => ewp.WeaponProperty)
                    .WithMany()
                    .HasForeignKey(ewp => ewp.WeaponPropertyId),
                    ewp => ewp.HasOne(ewp => ewp.Equipment)
                    .WithMany()
                    .HasForeignKey(ewp => ewp.EquipmentId));

            //define the composite key for EquipmentWeaponProperties
            modelBuilder.Entity<EquipmentWeaponProperty>()
                .HasKey(ewp => new { ewp.EquipmentId, ewp.WeaponPropertyId });

            //define the composite key and foreign keys for PackContents
            modelBuilder.Entity<PackContent>()
                .HasKey(e => new { e.PackId, e.ContentId });
            modelBuilder.Entity<PackContent>()
                .HasOne(pc => pc.PackEquipment)
                .WithMany(e => e.PackContents)
                .HasForeignKey(pc => pc.PackId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<PackContent>()
                .HasOne(pc => pc.ContentEquipment)
                .WithMany()
                .HasForeignKey(pc => pc.ContentId)
                .OnDelete(DeleteBehavior.Restrict);

            //define the composite key for PlayerItems
            modelBuilder.Entity<PlayerItem>()
                .HasKey (e => new { e.ItemId, e.PlayerCharacterId });
        }
    }
}
