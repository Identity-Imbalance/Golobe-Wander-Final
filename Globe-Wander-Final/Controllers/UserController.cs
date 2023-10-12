using Microsoft.AspNetCore.Mvc;

namespace Globe_Wander_Final.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
