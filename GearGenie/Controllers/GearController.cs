using GearGenie.Data;
using GearGenie.Models;
using GearGenie.Models.ViewModels;
using GearGenie.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //certain features are disabled if the user isn't logged in
            var homeVM = new HomeViewModel();
            if (User.Identity != null && !User.Identity.IsAuthenticated)
            {
                homeVM.UserAuthorized = false;
            }
            else
            {
                homeVM.UserAuthorized = true;
                var userID = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new Exception("userID is null");
                homeVM.Campaigns = await _gearContext.GetCampaigns(userID).ConfigureAwait(false);
            }
            
            return View(homeVM);
        }

        [HttpGet]
        public async Task<IActionResult> NewCampaign()
        {
            var newCampaignVM = new NewCampaignViewModel();

            return View(newCampaignVM);
        }

        [HttpPost]
        public async Task<IActionResult> NewCampaign(NewCampaignViewModel newCampaignVM)
        {
            if (newCampaignVM == null)
            {
                throw new Exception("Campaign view model missing data");
            }

            if(ModelState.IsValid)
            {

                return RedirectToAction("Index");
            }
            else
            {
                return View(newCampaignVM);
            }
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
