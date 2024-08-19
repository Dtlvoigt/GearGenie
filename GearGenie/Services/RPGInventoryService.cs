using Microsoft.IdentityModel.Tokens;

namespace GearGenie.Services
{
    public class RPGInventoryService : IRPGInventoryService
    {


        //////////////////
        // file loading //
        //////////////////
        
        public async Task LoadEquipmentCategories()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://www.dnd5eapi.co/api/equipment-categories");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
            }
        }
    }
}
