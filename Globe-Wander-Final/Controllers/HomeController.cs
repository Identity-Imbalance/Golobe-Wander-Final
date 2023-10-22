using Globe_Wander_Final.Models;
using Globe_Wander_Final.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Globe_Wander_Final.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITourSpot _tour;
        

        public HomeController(ILogger<HomeController> logger , ITourSpot tour)
        {
            _logger = logger;
            _tour = tour;
            
        }
        
        public async Task<IActionResult> Index()
        {
           var tour =  await _tour.GetAllTourSpots();
            return View(tour);
        }

        public IActionResult about()
        {
            return View("about");
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
