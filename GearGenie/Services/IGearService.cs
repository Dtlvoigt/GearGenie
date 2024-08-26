﻿using GearGenie.Models;

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
    }
}
