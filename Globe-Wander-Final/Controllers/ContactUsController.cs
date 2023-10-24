using Globe_Wander_Final.Models;
using Globe_Wander_Final.Models.DTOs;
using Globe_Wander_Final.Models.Interfaces;
using Globe_Wander_Final.Models.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Globe_Wander_Final.Controllers
{
    public class ContactUsController : Controller
    {

        private readonly EmailService _emailService;

        public ContactUsController(EmailService emailService)
        { 
        _emailService = emailService;
        }
           
  
        public async Task<IActionResult> Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index([Bind(Prefix = "")] EmailDTO email)
        {

            if (!ModelState.IsValid)
            {
               
                return View(email);
            }

            await _emailService.sendEmail(email);

            return RedirectToAction("Index", "Home");
        }
    }
}

        
        


