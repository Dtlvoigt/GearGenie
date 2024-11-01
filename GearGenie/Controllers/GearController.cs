using GearGenie.Data;
using GearGenie.Models;
using GearGenie.Models.ViewModels;
using GearGenie.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GearGenie.Controllers
{
    public class GearController : Controller
    {
        //private readonly IGearService _serviceContext;
        private readonly IEquipmentService _equipmentContext;
        private readonly ILogger<GearController> _logger;

        public GearController(IGearService gearContext, IEquipmentService equipmentContext, ILogger<GearController> logger)
        {
            //_serviceContext = gearContext;
            _equipmentContext = equipmentContext;
            _logger = logger;


            
        }

        public async Task<IActionResult> Index()
        {
            //_serviceContext.LoadEquipmentCategories();///
            //_serviceContext.LoadWeaponProperties();
            //_serviceContext.LoadEquipment();
            await _equipmentContext.DatabaseTests();
            


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
