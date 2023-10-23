using Globe_Wander_Final.Models;
using Globe_Wander_Final.Models.Interfaces;
using Globe_Wander_Final.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Globe_Wander_Final.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITourSpot _tour;
        private readonly ITrip _trip;
        private readonly IHotel _hotel;
        private readonly IHotelRoom _room;

        public HomeController(ILogger<HomeController> logger , ITourSpot tour,ITrip trip,IHotel hotel,IHotelRoom hotelRoom)
        {
            _logger = logger;
            _tour = tour;
            _trip = trip;
            _hotel = hotel;
            _room = hotelRoom;
        }
        
        public async Task<IActionResult> Index()
        {
           var tourSpots =  await _tour.GetAllTourSpots();
           var trips = await _trip.GetAllTrips();
           var hotel = await _hotel.GetAllHotels();
           var hotelRoom = await _room.GetHotelRooms();
           var viewModel = new TourViewModel
            {
                Trips = trips,
                TourSpots = tourSpots,
                recomandedHotels = hotel,
                
               

           };

            return View(viewModel);
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
