using Microsoft.AspNetCore.Mvc;
using Globe_Wander_Final.Models.Services;
using Globe_Wander_Final.Models.Interfaces;
using Globe_Wander_Final.Models.DTOs;
using Globe_Wander_Final.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Stripe.Checkout;
using Stripe;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Globe_Wander_Final.Models;

namespace Globe_Wander_Final.Controllers
{
    public class BookingTripsController : Controller
    {
        private readonly ITrip _trip; // Replace ITrip with the appropriate interface for your trips
        private readonly IBookingTrip _bookingTrip;
        //private readonly UPDATEBOOKINGTRIPServices _UPDATEBOOKINGTRIPServices;

        public BookingTripsController(ITrip trip, IBookingTrip bookingTrip)
        {
            _trip = trip;
            _bookingTrip = bookingTrip;
            //_UPDATEBOOKINGTRIPServices = UPDATEBOOKINGTRIPServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BookingHistory()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> BookingForm(int TripID)
        {
            var trip = await _trip.GetTripByID(TripID);
            var tripAndBookingForm = new TripAndBookingTrip
            {
                TripDTO = trip,
            };

            return View(tripAndBookingForm);
        }

        [HttpPost]
        public async Task<IActionResult> BookingForm(TripAndBookingTrip tripAndBookingForm)
        {
            var Trip = await _trip.GetTripByID(tripAndBookingForm.NewBookingTripDTO.TripID);
            var booking = await _bookingTrip.Create(tripAndBookingForm.NewBookingTripDTO, User);
            var nameOfTrip = Trip.Name;
            StripeConfiguration.ApiKey = "sk_test_51NubdTFevC2H5P3dnpmteGXkcBY9039zcaJJYEs6S5frHIj0BzpWYid6eXGNJPjfKo1nuw7rb3Pm0kEwSZKspkOX00Z1a00TTs";

            var domain = "https://localhost:7062/";

            var options = new SessionCreateOptions
            {
                SuccessUrl = domain + $"BookingRooms/MyBookings",
                CancelUrl = domain + $"Home/Index",
                LineItems = new List<SessionLineItemOptions>(),
                Mode = "payment",
            };


            var sessionLineItem = new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions()
                {
                    UnitAmount = (long)(booking.TotalPrice * 100), // 20.50 => 2050
                    Currency = "usd",
                    ProductData = new SessionLineItemPriceDataProductDataOptions()
                    {
                        Name = nameOfTrip
                    }
                },
                Quantity = 1

            };

            options.LineItems.Add(sessionLineItem);

            var service = new SessionService();
            var session = service.Create(options);

            var sessionId = session.Id;

            TempData["sessionId"] = sessionId;

            Response.Headers.Add("Location", session.Url);



            return new StatusCodeResult(303);


        }

    }
}
