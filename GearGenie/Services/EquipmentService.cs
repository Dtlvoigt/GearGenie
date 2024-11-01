using GearGenie.Data;
using Microsoft.EntityFrameworkCore;

namespace GearGenie.Services
{
    public class EquipmentService: IEquipmentService
    {
        private IEquipmentContext _equipmentContext;

        public EquipmentService(IEquipmentContext equipmentContext)
        {
            _equipmentContext = equipmentContext;
        }

        public async Task DatabaseTests()
        {
            var categories = await _equipmentContext.Categories.ToListAsync();
            var equipment = await _equipmentContext.Equipment.Include(e => e.WeaponProperties).Include(e => e.PackContents).ToListAsync();
            var weaponProperties = await _equipmentContext.WeaponProperties.ToListAsync();
            var pcRelationships = await _equipmentContext.PackContents.ToListAsync();
            var wpRelationships = await _equipmentContext.EquipmentWeaponProperties.ToListAsync();
            var weapons = await _equipmentContext.Equipment.Where(e => e.Category == "Weapon").Include(e => e.WeaponProperties).ToListAsync();
            var variantItems = await _equipmentContext.Equipment.Where(e => e.HasVariant).ToListAsync();
            var packsAndContents = await _equipmentContext.Equipment.Where(e => e.GearCategory == "Equipment Packs").Include(e => e.PackContents).ToListAsync();
        }
    }
}
