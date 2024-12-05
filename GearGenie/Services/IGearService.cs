using GearGenie.Models;
using GearGenie.Models.EquipmentModels;
using GearGenie.Models.InventoryModels;

namespace GearGenie.Services
{
    public interface IGearService
    {
        //search database
        Task<List<Campaign>> GetCampaigns(string userID);
        Task<List<PlayerCharacter>> GetUserPlayerCharacters(string userID);
        Task<List<PlayerCharacter>> GetCampaignPlayerCharacters(int campaignID);

        //update database
        Task<int> AddCampaign(Campaign campaign);


        //file loading
        //Task LoadEquipment();
        //Task LoadEquipmentCategories();
        //Task<List<String>> LoadEquipmentURLs();
        //Task LoadWeaponProperties();
        //Task<Equipment> ParseEquipmentProperties(string json);


        Task DatabaseTests();

        //helper functions
        float ConvertMoneyToGold(float amount, string coinType);
    }
}
