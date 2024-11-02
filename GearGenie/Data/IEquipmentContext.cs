﻿using GearGenie.Models.EquipmentModels;
using GearGenie.Models.InventoryModels;
using Microsoft.EntityFrameworkCore;

namespace GearGenie.Data
{
    public interface IEquipmentContext : IDisposable
    {
        DbSet<Equipment> Equipment { get; set; }
        DbSet<EquipmentCategory> Categories { get; set; }
        DbSet<WeaponProperty> WeaponProperties { get; set; }
        DbSet<EquipmentWeaponProperty> EquipmentWeaponProperties { get; set; }
        DbSet<PackContent> PackContents { get; set; }
        DbSet<PlayerCharacter> PlayerCharacters { get; set; }
        DbSet<PlayerItem> PlayerItems { get; set; }

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
