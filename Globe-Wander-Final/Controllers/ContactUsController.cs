using Globe_Wander_Final.Models;
using Globe_Wander_Final.Models.DTOs;
using Globe_Wander_Final.Models.Interfaces;
using Globe_Wander_Final.Models.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        public async Task<IActionResult> Index( EmailDTO email)
        {

            email.Email = User.FindFirst(ClaimTypes.Email)?.Value;
            var user = User.Identity.Name;
            await _emailService.sendEmail(user,email);

            return RedirectToAction("Index", "Home");
        }
    }
}

        
        


