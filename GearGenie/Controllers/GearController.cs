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
        private readonly IGearService _gearContext;
        private readonly ILogger<GearController> _logger;

        public GearController(IGearService gearContext, ILogger<GearController> logger)
        {
            //_serviceContext = gearContext;
            _gearContext = gearContext;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            //await _gearContext.DatabaseTests();
            
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
