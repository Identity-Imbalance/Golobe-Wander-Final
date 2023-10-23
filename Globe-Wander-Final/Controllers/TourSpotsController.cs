using Globe_Wander_Final.Models.DTOs;
using Globe_Wander_Final.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;

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

        public async Task<IActionResult> GetSpotById(int spotId)
        {
            var tourId = await _tours.GetSpotById(spotId);
            return View(tourId);
        }

        public async Task<IActionResult> ListTourSpots()
        {
            var tours = await _tours.GetAllTourSpots();

            return View(tours);
        }

        [Authorize(Roles = "Admin Manager")]
        public async Task<IActionResult> CreateTourSpot()
        {
            return View();
        }

        [Authorize(Roles = "Admin Manager")]
        [HttpPost]
        public async Task<IActionResult> CreateTourSpot(newTourSpotDTO model, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                await _tours.CreateTourSpot(model, image);

                return RedirectToAction("ListTourSpots", "TourSpots");
            }
            return View(model); 
        }

        [Authorize(Roles = "Admin Manager")]
        public async Task<IActionResult> EditTourSpot(int id)
        {
            var tour = await _tours.GetSpotById(id);

            return View(tour);
        }

        [Authorize(Roles = "Admin Manager")]
        [HttpPost]
        public async Task<IActionResult> EditTourSpot(newTourSpotDTO model, IFormFile image)
        {
            
                var tour = await _tours.UpdateTourSpot(model, model.ID, image);
                if (tour != null)
                {
                    return RedirectToAction("ListTourSpots", "TourSpots");
                }
            
            var notValidTour = await _tours.GetSpotById(model.ID);
            return View(notValidTour);
        }

        [Authorize(Roles = "Admin Manager")]
        [HttpPost]
        public async Task<IActionResult> DeleteTourSpot(int id)
        {
             await _tours.DeleteTourSpot(id);

            return RedirectToAction("ListTourSpots", "TourSpots");
        }
    }
}
