using Globe_Wander_Final.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Globe_Wander_Final.Controllers
{
    public class TourSpotsController : Controller
    {
        private readonly ITourSpot _tours;
        public TourSpotsController(ITourSpot tours)
        {
            _tours = tours;
        }

       
       
        public async Task<IActionResult> Index()
        {
            var tours = await _tours.GetAllTourSpots();

            return View(tours);
        }
    }
}
