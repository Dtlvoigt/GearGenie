using GearGenie.Models;
using GearGenie.Models.EquipmentModels;

namespace GearGenie.Services
{
    public interface IGearService
    {
        //file loading
        Task LoadEquipment();
        Task LoadEquipmentCategories();
        Task<List<String>> LoadEquipmentURLs();
        Task LoadWeaponProperties();
        Task<Equipment> ParseEquipmentProperties(string json);


        Task DatabaseTests();

        //helper functions
        float ConvertMoneyToGold(float amount, string coinType);
    }
}
