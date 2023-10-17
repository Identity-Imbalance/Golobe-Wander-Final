using Globe_Wander_Final.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Globe_Wander_Final.Controllers
{
    
    public class TripsController : Controller
    {
        private readonly ITrip _trips;

        public TripsController(ITrip trips)
        {
            _trips = trips;
        }
        public async Task<IActionResult> Trips()
        {
            var Alltrip = await _trips.GetAllTrips();

            return View(Alltrip);
        }

        public async Task<IActionResult> TripDetails(int id)
        {

            var trip = await _trips.GetTripByID(id);
            return View(trip);
        }
    }
}
