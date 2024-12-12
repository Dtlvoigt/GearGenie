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
        Task<List<PlayerItem>> GetPlayerItems(string userID);
        Task<List<Shop>> GetShops();
        Task<List<Shop>> GetCampaignShops(int campaignID);

        //update database
        Task<int> AddCampaign(Campaign campaign);
        Task<int> AddPlayerCharacter(PlayerCharacter playerCharacter, int campaignID = 0);


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
