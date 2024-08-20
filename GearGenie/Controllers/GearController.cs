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
        private readonly IGearService _serviceContext;
        private readonly ILogger<GearController> _logger;

        public GearController(IGearService context, ILogger<GearController> logger)
        {
            _serviceContext = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            _serviceContext.LoadEquipmentCategories();///
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
