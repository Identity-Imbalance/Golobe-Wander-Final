using Globe_Wander_Final.Models.DTOs;
using Globe_Wander_Final.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Globe_Wander_Final.Controllers
{
    public class RatesController : Controller
    {
        private readonly IRate _rate;

        public RatesController(IRate rate)
        {
            _rate = rate;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BookingTripRate(int TripID, int Rating, string Comments)
        {
            NewRateDTO newRate = new NewRateDTO
            {
                TripID = TripID,
                Rating = Rating,
                Comments = Comments
            };

            var rate = await _rate.Create(newRate, User); 
            if (rate != null)
            {
                return RedirectToAction("Trips", "Trips");
            }
            else
            {
                return RedirectToAction("Index","Home");
            }
        }
    }
}
