using Microsoft.AspNetCore.Mvc;

namespace Globe_Wander_Final.Controllers
{
    public class BookingTripsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
