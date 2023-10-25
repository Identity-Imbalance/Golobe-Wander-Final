using Globe_Wander_Final.Models.DTOs;
using Globe_Wander_Final.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace Globe_Wander_Final.Pages
{
    [Authorize(Roles = "Admin Manager, Trip Manager, Hotel Manager")]
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)] // Disable caching

    public class DashboardModel : PageModel
    {

        private readonly ITourSpot _tour;
        private readonly ITrip _trip;
        private readonly IHotel _hotel;
        private readonly IBookingRoom _bookingRoom;
        private readonly IBookingTrip _bookingTrip;
        private readonly IRate _rate;

        public DashboardModel(ITourSpot tour, ITrip trip, IHotel hotel, IBookingRoom bookingRoom, IBookingTrip bookingTrip, IRate rate)
        {
            _tour = tour;
            _trip = trip;
            _hotel = hotel;
            _bookingRoom = bookingRoom;
            _bookingTrip = bookingTrip;
            _rate = rate;
            combinedList = new List<object>();
        }


        public int ToursCount { get; set; }
        public int TripCount { get; set; }
        public int HotelCount { get; set; }
        public int BookingsCount { get; set; }
        public int RateCount { get; set; }

        public List<object> combinedList { get; set; }


        public async Task OnGet()
        {
            var tours = await _tour.GetAllTourSpots();
            ToursCount = tours.Count;

            var hotels = await _hotel.GetAllHotels();
            HotelCount = hotels.Count();

            var trips = await _trip.GetAllTrips();
            TripCount = trips.Count();

            var bookingRooms = await _bookingRoom.GetAllBookingRooms();
            var bookingTrips = await _bookingTrip.GetAllBookingTrips();

            BookingsCount = bookingRooms.Count() + bookingTrips.Count();

            var rates = await _rate.GetAllRate();

            RateCount = rates.Count();

            // TODO: Add the both bookings inside this list and filter it and should be returned in the view sorted on the start date.

            if (bookingRooms.Count > 0)
            {
                combinedList.AddRange(bookingRooms);

            }
            if (bookingTrips.Count > 0)
            {

                combinedList.AddRange(bookingTrips);
            }
            combinedList = combinedList
            .OrderBy(item =>
              {
                  if (item is BookingRoomDTO bookingRoomDTO)
                  {
                      return bookingRoomDTO.CheckIn;
                  }
                  else if (item is BookingTripDTO bookingTripDTO)
                  {
                      return bookingTripDTO.StartDate;
                  }
                  // Handle other types if needed
                  return DateTime.MinValue;
              }).ToList();


        }
    }
}
