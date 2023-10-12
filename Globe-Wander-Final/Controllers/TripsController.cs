using Microsoft.AspNetCore.Mvc;

namespace Globe_Wander_Final.Controllers
{
    public class TripsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
