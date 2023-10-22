using Globe_Wander_Final.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Globe_Wander_Final.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> GetSpotById(int spotId)
        {
            var tourId = await _tours.GetSpotById(spotId);
            return View(tourId);
        }
    }
}
