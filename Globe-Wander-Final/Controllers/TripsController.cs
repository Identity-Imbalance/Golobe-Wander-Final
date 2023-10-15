using Microsoft.AspNetCore.Mvc;

namespace Globe_Wander_Final.Controllers
{
    public class TripsController : Controller
    {
        public IActionResult Trips()
        {
            return View();
        }
    }
}
