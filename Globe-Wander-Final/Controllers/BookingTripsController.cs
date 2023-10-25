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
        private readonly UPDATEBOOKINGTRIPServices _UPDATEBOOKINGTRIPServices;

        public BookingTripsController(ITrip trip, IBookingTrip bookingTrip, UPDATEBOOKINGTRIPServices UPDATEBOOKINGTRIPServices)
        {
            _trip = trip;
            _bookingTrip = bookingTrip;
            _UPDATEBOOKINGTRIPServices = UPDATEBOOKINGTRIPServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BookingHistory()
        {
            return View();
        }

        public async Task<IActionResult> UpdateOnlyCheckOut(int Id)
        {

            var booking = await _bookingTrip.GetBookingTripById(Id);

            return View(booking);

        }
        public async Task<IActionResult> Overlap(int Id)
        {

            var booking = await _bookingTrip.GetBookingTripById(Id);

            return View(booking);

        }
        public async Task<IActionResult> CompletedPaidBooking(int ID)
        {

            var booking = await _bookingTrip.GetBookingTripById(ID);


            return View(booking);

        }
        public async Task<IActionResult> RefundMessage(int ID)
        {

            return View(ID);

        }
        public async Task<IActionResult> CompletedPaymentMessage(int ID)
        {

            var UpdateBooking = await _UPDATEBOOKINGTRIPServices.get(ID);
            UpdateBookingTripDTO newbooking = new UpdateBookingTripDTO()
            {

                ID = UpdateBooking.IdForUpdate,
                NumberOfPersons = UpdateBooking.NumberOfPersons

            };

            var updated = await _bookingTrip.UpdateBookingTrip(UpdateBooking.IdForUpdate, newbooking);

            await _UPDATEBOOKINGTRIPServices.Delete(ID);
            return View(updated);

        }

        public async Task<IActionResult> FailedPayment(int Id)
        {
            var bookingTrip = await _bookingTrip.GetBookingTripById(Id);

            await _bookingTrip.DeleteBookingTrip(Id,bookingTrip.TripID);

            return View();

        }

        public async Task<IActionResult> FailedPaymentExtra(int ID)
        {

            await _UPDATEBOOKINGTRIPServices.Delete(ID);
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
        //TODO: max of the input is should be capacity - count  -- Osama
        public async Task<IActionResult> BookingForm(TripAndBookingTrip tripAndBookingForm)
        {
            var BookingTripData = await _bookingTrip.GetAllBookingRoomsForUser(User.Identity.Name);

            var Trip = await _trip.GetTripByID(tripAndBookingForm.NewBookingTripDTO.TripID);

            tripAndBookingForm.NewBookingTripDTO.StartDate = Trip.StartDate;

            tripAndBookingForm.NewBookingTripDTO.EndDate = Trip.EndDate;

            foreach (var trip in BookingTripData)
            {
                if (tripAndBookingForm.NewBookingTripDTO.StartDate <= trip.EndDate && tripAndBookingForm.NewBookingTripDTO.EndDate >= trip.StartDate)
                {
                    return RedirectToAction("Overlap", new { Id = trip.ID  });
                }



            }
            
            var booking = await _bookingTrip.Create(tripAndBookingForm.NewBookingTripDTO, User);
            var nameOfTrip = Trip.Name;
            StripeConfiguration.ApiKey = "sk_test_51NubdTFevC2H5P3dnpmteGXkcBY9039zcaJJYEs6S5frHIj0BzpWYid6eXGNJPjfKo1nuw7rb3Pm0kEwSZKspkOX00Z1a00TTs";

            var domain = "https://localhost:7062/";

            var options = new SessionCreateOptions
            {
                SuccessUrl = domain + $"BookingTrips/CompletedPaidBooking/{booking.ID}",
                CancelUrl = domain + $"BookingTrips/FailedPayment/{booking.ID}",
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

        [HttpPost]
        public async Task<IActionResult> UserDeleteBooking(int Id)
        {
            var bookingTrip = await _bookingTrip.GetBookingTripById(Id);

            await _bookingTrip.DeleteBookingTrip(Id,bookingTrip.TripID);

            return RedirectToAction("MyBookings","BookingRooms");
        }

        public async Task<IActionResult> UserUpdateBooking(int Id)
        {

            var BookingData = await _bookingTrip.GetBookingTripById(Id);
            var trip = await _trip.GetTripByID(BookingData.TripID);
            var BOOKING = new UpdateTripBooking()
            {
                bookingTripDTO = BookingData,
                TripDTO = trip
            };

            return View(BOOKING);

        }
        [HttpPost]
        public async Task<IActionResult> UserUpdateBooking(UpdateBookingTripDTO UpdateBooking)
        {
            var BookingData = await _bookingTrip.GetBookingTripById(UpdateBooking.ID);
             UpdateBooking.StartDate = BookingData.StartDate;
            UpdateBooking.EndDate = BookingData.EndDate;
            var totalBeforeUpdate = BookingData.TotalPrice;

            //var updated = await _bookingRoom.UpdateBookingRoom(UpdateBooking.ID, UpdateBooking);
            var totalAfterUpdate = UpdateBooking.NumberOfPersons * BookingData.CostPerPerson;


            if (totalBeforeUpdate > totalAfterUpdate)
            {
                await _bookingTrip.UpdateBookingTripByUser(UpdateBooking.ID, UpdateBooking);
                var totalRefund = totalBeforeUpdate - totalAfterUpdate;
                int totalRefundInt = Convert.ToInt32(totalRefund);

                return RedirectToAction("RefundMessage", new { ID = totalRefundInt });

            }

            var UPDATEBOOKINGTEMP = await _UPDATEBOOKINGTRIPServices.Create(UpdateBooking);


            var totalExtra = totalAfterUpdate - totalBeforeUpdate;
            if (totalBeforeUpdate < totalAfterUpdate)
            {

                StripeConfiguration.ApiKey = "sk_test_51NubdTFevC2H5P3dnpmteGXkcBY9039zcaJJYEs6S5frHIj0BzpWYid6eXGNJPjfKo1nuw7rb3Pm0kEwSZKspkOX00Z1a00TTs";

                var domain = "https://localhost:7062/";

                var options = new SessionCreateOptions
                {
                    SuccessUrl = domain + $"BookingTrips/CompletedPaymentMessage/{UPDATEBOOKINGTEMP.ID}",
                    CancelUrl = domain + $"BookingTrips/FailedPaymentExtra/{UPDATEBOOKINGTEMP.ID}",
                    LineItems = new List<SessionLineItemOptions>(),
                    Mode = "payment",
                };


                var sessionLineItem = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions()
                    {
                        UnitAmount = (long)(totalExtra * 100), // 20.50 => 2050
                        Currency = "usd",
                        ProductData = new SessionLineItemPriceDataProductDataOptions()
                        {
                            Name = "Extra Total Cost"
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
            await _UPDATEBOOKINGTRIPServices.Delete(UpdateBooking.ID);
            return RedirectToAction("MyBookings", "BookingRooms");





        }

    }
}
