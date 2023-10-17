using Globe_Wander_Final.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Globe_Wander_Final.Controllers
{
    public class ContactUsController : Controller
    {
         [Route("api/[controller]")]
        [HttpGet]
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}

        
        


