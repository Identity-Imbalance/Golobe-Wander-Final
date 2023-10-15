using Globe_Wander_Final.Models;
using Globe_Wander_Final.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;

namespace Globe_Wander_Final.Controllers
{
    public class HotelsController : Controller
    {
        private readonly IHotel _hotels;

        public HotelsController(IHotel hotels)
        {
            _hotels = hotels;
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


        public async Task<IActionResult> GetById(int Id)
        {
            var hotel = await _hotels.GetHotelId(Id);
            var hotels = await _hotels.GetAllHotels();
            var reco =new RecomandHotelsANDHotelMV()
            {hotel = hotel,
            recomandedHotels = hotels

            };
            return View(reco);
        }
    }
}
