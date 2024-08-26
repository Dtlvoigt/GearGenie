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

        public async Task LoadEquipment()
        {
            try
            {
                var equipmentURLs = await LoadEquipmentURLs();
                var equipmentList = new List<Equipment>();
                foreach (var url in equipmentURLs)
                {
                    var httpClient = new HttpClient();
                    var response = await httpClient.GetAsync("https://www.dnd5eapi.co" + url);
                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        var document = JsonDocument.Parse(json);
                        var equipment = JsonSerializer.Deserialize<Equipment>(document);
                        if (equipment != null)
                        {
                            equipmentList.Add(equipment);
                            Console.WriteLine(equipment.Name + " added.");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async Task LoadEquipmentCategories()
        {
            try
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync("https://www.dnd5eapi.co/api/equipment-categories");
                var categories = new List<EquipmentCategory>();
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var document = JsonDocument.Parse(json);
                    var root = document.RootElement.GetProperty("results");
                    categories = JsonSerializer.Deserialize<List<EquipmentCategory>>(root);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public async Task<List<String>> LoadEquipmentURLs()
        {
            var equipmentURLs = new List<String>();

            try
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync("https://www.dnd5eapi.co/api/equipment");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var document = JsonDocument.Parse(json);
                    var root = document.RootElement.GetProperty("results");
                    equipmentURLs = root.EnumerateArray()
                                        .Select(e => e.GetProperty("url").GetString())
                                        .ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return equipmentURLs;
        }

        public async Task LoadWeaponProperties()
        {
            var weaponProperties = new List<WeaponProperty>();

            try
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync("https://www.dnd5eapi.co/api/weapon-properties");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var document = JsonDocument.Parse(json);
                    var root = document.RootElement.GetProperty("results");
                    weaponProperties = JsonSerializer.Deserialize<List<WeaponProperty>>(root);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
