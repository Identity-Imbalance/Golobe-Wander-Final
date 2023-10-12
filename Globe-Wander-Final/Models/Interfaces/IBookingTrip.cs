﻿using Globe_Wander_Final.Models.DTOs;
using System.Security.Claims;

namespace Globe_Wander_Final.Models.Interfaces
{
    public interface IBookingTrip
    {
        // Create Booking Trip
        Task<BookingTripDTO> Create(NewBookingTripDTO bookingTrip, ClaimsPrincipal userPrincipal);

        // GET All Booking Trips
        Task<List<BookingTripDTO>> GetAllBookingTrips();

        // GET by ID
        Task<BookingTripDTO> GetBookingTripById(int id);

        // UPDATE
        Task<BookingTripDTO> UpdateBookingTrip(int id, UpdateBookingTripDTO updateBookingTrip, int tripId);

        // DELET by ID
        Task Delete(int id, int tripId);
    }
}
