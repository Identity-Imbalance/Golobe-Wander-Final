using Globe_Wander_Final.Models;
using Globe_Wander_Final.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;

namespace Globe_Wander_Final.Controllers
{
    public class HotelsController : Controller
    {
        private readonly IHotel _hotels;

        private readonly ITourSpot _tourSpot;

        public HotelsController(IHotel hotels, ITourSpot tourSpot)
        {
            _hotels = hotels;
            _tourSpot = tourSpot;
        }
        public  async Task<IActionResult> Index()
        {
            var hotels =await _hotels.GetAllHotels();
            return View(hotels);
        }

        public async Task<IActionResult> Hotel()
        {
            var hotels = await _hotels.GetAllHotels();
            return View(hotels);
        }


        public async Task<IActionResult> SingleHotel(int Id)
        {
            var hotel = await _hotels.GetHotelId(Id);
            var hotels = await _hotels.GetAllHotels();
            var reco =new RecomandHotelsANDHotelMV()
            {hotel = hotel,
            recomandedHotels = hotels

            };
            return View(reco);
        }

        public async Task<IActionResult> CreateHotel()
        {
            var tourSpots = await _tourSpot.GetAllTourSpots();

            // Store the tour spots in ViewBag to pass it to the view
            ViewBag.TourSpots = tourSpots;
            return View();
        }

        public async Task<IActionResult> ListHotels()
        {
            var hotels = await _hotels.GetAllHotels();
            return View(hotels);
        }
    }
}
