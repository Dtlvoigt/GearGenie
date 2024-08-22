using GearGenie.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace GearGenie.Services
{
    public class GearService : IGearService
    {


        //////////////////
        // file loading //
        //////////////////
        
        public async Task LoadEquipmentCategories()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://www.dnd5eapi.co/api/equipment-categories");
            var categories = new List<EquipmentCategory>();
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                JsonNode? node = JsonNode.Parse(json);
                JsonNode root = node.Root;
                categories = JsonSerializer.Deserialize<List<EquipmentCategory>>(root["results"]);
            }
        }
    }
}
