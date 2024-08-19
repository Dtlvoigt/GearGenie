using GearGenie.Data;
using GearGenie.Models;
using GearGenie.Models.ViewModels;
using GearGenie.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GearGenie.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRPGInventoryService _serviceContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IRPGInventoryService context, ILogger<HomeController> logger)
        {
            _serviceContext = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            _serviceContext.LoadEquipmentCategories();
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
