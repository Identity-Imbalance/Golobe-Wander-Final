using Globe_Wander_Final.Models;
using Globe_Wander_Final.Models.DTOs;
using Globe_Wander_Final.Models.Interfaces;
using Globe_Wander_Final.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using Stripe;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Globe_Wander_Final.Models.Services;

namespace Globe_Wander_Final.Controllers
{
    public class BookingRoomsController : Controller
    {
        private readonly IHotelRoom _hotelRoom;
        private readonly IBookingRoom _bookingRoom;
        private readonly IHotel _hotel;
        private readonly UPDATEBOOKINGTEMPServices _UPDATEBOOKINGTEMPServices ;
        private readonly IBookingTrip _bookingTrips;
        private readonly ITrip _trip;
        public BookingRoomsController(IHotelRoom hotelRoom, IBookingRoom bookingRoom, IHotel hotel, UPDATEBOOKINGTEMPServices UPDATEBOOKINGTEMPServices, IBookingTrip bookingTrips, ITrip trip)
        {
            _hotelRoom = hotelRoom;
            _bookingRoom = bookingRoom;
            _hotel = hotel;
            _UPDATEBOOKINGTEMPServices = UPDATEBOOKINGTEMPServices;
            _bookingTrips  = bookingTrips;
            _trip = trip;



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
        public async Task<IActionResult> BookingForm(int HotelID, int RoomNumber)
        {

            var hotelRoom = await _hotelRoom.GetHotelRoomId(HotelID, RoomNumber);
            var hotelRoomAndBookingForm = new HotelRoomandBooking
            {
                HotelRoomDTO = hotelRoom,
            };

            return View(hotelRoomAndBookingForm);
        }

        [HttpPost]
        public async Task<IActionResult> BookingForm(HotelRoomandBooking hotelRoomAndBookingForm)
        {
            var hotelRoom = await _hotelRoom.GetHotelRoomId(hotelRoomAndBookingForm.NewBookingRoomDTO.HotelID, hotelRoomAndBookingForm.NewBookingRoomDTO.RoomNumber);
           var user = User.Identity.Name;
           var booking = await _bookingRoom.CreateBookingRoom(hotelRoomAndBookingForm.NewBookingRoomDTO, user);
            var nameOfRoom = hotelRoom.Rooms.Name;
                StripeConfiguration.ApiKey = "sk_test_51NubdTFevC2H5P3dnpmteGXkcBY9039zcaJJYEs6S5frHIj0BzpWYid6eXGNJPjfKo1nuw7rb3Pm0kEwSZKspkOX00Z1a00TTs";
       
                var domain = "https://localhost:7062/";

                var options = new SessionCreateOptions
                {
                    SuccessUrl = domain + $"BookingRooms/CompletedPaidBooking/{booking.ID}",
                    CancelUrl = domain + $"BookingRooms/FailedPayment/{booking.ID}",
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
                                Name = nameOfRoom
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
        public async Task<IActionResult> CompletedPaidBooking(int ID)
        {

        var booking =  await _bookingRoom.GetBookingRoomById(ID);


            return View(booking);

        }
        public async Task<IActionResult> RefundMessage(int ID)
        {

            


            return View(ID);

        }
        public async Task<IActionResult> CompletedPaymentMessage(int ID)
        {

            var UpdateBooking = await _UPDATEBOOKINGTEMPServices.get(ID);
            DurationBookingRoomDTO newbooking = new DurationBookingRoomDTO() { 

            ID = UpdateBooking.IdForUpdate,
            CheckIn=UpdateBooking.CheckIn,
            CheckOut=UpdateBooking.CheckOut,
            
            
            };

            var updated = await _bookingRoom.UpdateBookingRoom(UpdateBooking.IdForUpdate, newbooking);


            await _UPDATEBOOKINGTEMPServices.Delete(ID);
            return View(updated);

        }

        public async Task<IActionResult> FailedPayment( int Id)
        {

    await _bookingRoom.DeleteBookingRoom(Id);
         
            return View();

        }

        public async Task<IActionResult> FailedPaymentExtra(int ID)
        {
          
            await _UPDATEBOOKINGTEMPServices.Delete(ID);
            return View();

        }
        public async Task<IActionResult> MyBookings()
        {
            var user = User.Identity.Name;

            var hotelRoomsData = await _hotelRoom.GetHotelRooms();

            var hotelsData = await _hotel.GetAllHotels();
            var BookingHotelData = await _bookingRoom.GetAllBookingRoomsForUser(User.Identity.Name);

            var BookingTripData = await _bookingTrips.GetAllBookingRoomsForUser(User.Identity.Name);
            var TripData = await _trip.GetAllTrips();



            var userbooking = new MyBookingsDTO
            {
                HotelRoomDTO = hotelRoomsData,
                HotelDTOs= hotelsData,
                BookingRoomDTO= BookingHotelData,
                 TripDTOs = TripData,


                BookingTripDTO = BookingTripData
            };



            return View(userbooking);
        }

        public async Task<IActionResult> UserDeleteBooking(int Id)
        {
          
           await _bookingRoom.DeleteBookingRoom(Id);
          


            return RedirectToAction("MyBookings");
        }

        public async Task<IActionResult> UserUpdateBooking(int Id)
        {

            var BookingData = await _bookingRoom.GetBookingRoomById(Id);
            var BOOKING = new UpdateBooking()
            {
                bookingRoom = BookingData,

            };

            return View(BOOKING);

        }
        [HttpPost]
        public async Task<IActionResult> UserUpdateBooking(DurationBookingRoomDTO UpdateBooking)
        {
            var BookingData = await _bookingRoom.GetBookingRoomById(UpdateBooking.ID);
            if (UpdateBooking.CheckIn<= DateTime.MinValue)
            {
                UpdateBooking.CheckIn = BookingData.CheckIn;
            }     

            var totalBeforeUpdate = BookingData.TotalPrice;
            TimeSpan duration = UpdateBooking.CheckOut - UpdateBooking.CheckIn;
            int totalDays = (int)duration.TotalDays;
            //var updated = await _bookingRoom.UpdateBookingRoom(UpdateBooking.ID, UpdateBooking);
            var totalAfterUpdate = totalDays * BookingData.Cost;

            
if(totalBeforeUpdate > totalAfterUpdate)
            {
      await _bookingRoom.UpdateBookingRoom(UpdateBooking.ID, UpdateBooking);
              var totalRefund =  totalBeforeUpdate - totalAfterUpdate;
                int totalRefundInt = Convert.ToInt32(totalRefund);

                return RedirectToAction("RefundMessage", new { ID = totalRefundInt });

            }

            var UPDATEBOOKINGTEMP = await _UPDATEBOOKINGTEMPServices.Create(UpdateBooking);


            var totalExtra = totalAfterUpdate - totalBeforeUpdate;
            if (totalBeforeUpdate < totalAfterUpdate)
            {
            
                StripeConfiguration.ApiKey = "sk_test_51NubdTFevC2H5P3dnpmteGXkcBY9039zcaJJYEs6S5frHIj0BzpWYid6eXGNJPjfKo1nuw7rb3Pm0kEwSZKspkOX00Z1a00TTs";

                var domain = "https://localhost:7062/";

                var options = new SessionCreateOptions
                {
                    SuccessUrl = domain + $"BookingRooms/CompletedPaymentMessage/{UPDATEBOOKINGTEMP.ID}",
                    CancelUrl = domain + $"BookingRooms/FailedPaymentExtra/{UPDATEBOOKINGTEMP.ID}",
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
                            Name = "Extra Days Total Cost"
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

            return RedirectToAction("MyBookings");





        }


    }
}
