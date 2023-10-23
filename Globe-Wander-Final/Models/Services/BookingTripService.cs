using Globe_Wander_Final.Data;
using Globe_Wander_Final.Models.DTOs;
using Globe_Wander_Final.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Globe_Wander_Final.Models.Services
{
    /// <summary>
    /// Service implementation for managing booking trips.
    /// </summary>
    public class BookingTripService : IBookingTrip
    {

        private readonly GlobeWanderDbContext _context;

        private UserManager<ApplicationUser> _UserManager;

        public BookingTripService(GlobeWanderDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _UserManager = userManager;
        }

        /// <summary>
        /// Create a new booking trip.
        /// </summary>
        /// <param name="bookingTrip">Data for the new booking trip.</param>
        /// <param name="userId">ID of the user making the booking.</param>
        public async Task<BookingTripDTO> Create(NewBookingTripDTO bookingTrip, ClaimsPrincipal userPrincipal)
        {
            var getUserId = userPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _UserManager.FindByIdAsync(getUserId);

            var trip = await _context.Trips.FindAsync(bookingTrip.TripID);

            var existBookingTrip = await _context.bookingTrips
                .Where(x => x.TripID == bookingTrip.TripID)
                .FirstOrDefaultAsync(b => b.Username == user.UserName && trip.Id == bookingTrip.TripID);

            if (existBookingTrip == null)
            {
                if (trip.Capacity >= (trip.Count + bookingTrip.NumberOfPersons))
                {
                    trip.Count += bookingTrip.NumberOfPersons;

                    // Calculate the duration based on StartDate and EndDate
                    int duration = (int)(bookingTrip.EndDate - bookingTrip.StartDate).TotalDays;

                    var newBookingTrip = new BookingTrip()
                    {
                        TripID = bookingTrip.TripID,
                        NumberOfPersons = bookingTrip.NumberOfPersons,
                        StartDate = bookingTrip.StartDate,
                        EndDate = bookingTrip.EndDate,
                        CostPerPerson = trip.Cost,
                        Duration = duration,
                        TotalPrice = bookingTrip.NumberOfPersons * trip.Cost,
                        Username = user.UserName
                    };

                    _context.Entry<BookingTrip>(newBookingTrip).State = EntityState.Added;
                    await _context.SaveChangesAsync();

                    var BookingTripDTO = await GetBookingTripById(newBookingTrip.ID);
                    BookingTripDTO.ID = newBookingTrip.ID;

                    return BookingTripDTO;
                }
                return null; // Capacity exceeded
            }
            return null; // Booking already exists
        }


        /// <summary>
        /// Get a booking trip by its ID and trip ID.
        /// </summary>
        /// <param name="id">ID of the booking trip.</param>
        /// <param name="tripId">ID of the trip associated with the booking trip.</param>
        public async Task<BookingTripDTO> GetBookingTripById(int id)
        {
            var bookingTrip = await _context.bookingTrips.FindAsync(id);

            if (bookingTrip != null)
            {
                var bookingTripDTO = new BookingTripDTO
                {
                    ID = bookingTrip.ID,
                    TripID = bookingTrip.TripID,
                    NumberOfPersons = bookingTrip.NumberOfPersons,
                    StartDate = bookingTrip.StartDate,
                    EndDate = bookingTrip.EndDate,
                    CostPerPerson = bookingTrip.CostPerPerson,
                    Duration = bookingTrip.Duration,
                    TotalPrice = bookingTrip.TotalPrice,
                    Username = bookingTrip.Username
                };

                return bookingTripDTO;
            }

            return null;
        }


        /// <summary>
        /// Get a list of all booking trips.
        /// </summary>
        public async Task<List<BookingTripDTO>> GetAllBookingTrips()
        {
            var bookingTrips = await _context.bookingTrips.ToListAsync();
            var bookingTripDTOs = bookingTrips.Select(bt => new BookingTripDTO
            {
                ID = bt.ID,
                TripID = bt.TripID,
                NumberOfPersons = bt.NumberOfPersons,
                StartDate = bt.StartDate,
                EndDate = bt.EndDate,
                CostPerPerson = bt.CostPerPerson,
                Duration = bt.Duration,
                TotalPrice = bt.TotalPrice,
                Username = bt.Username
            }).ToList();

            return bookingTripDTOs;
        }


        /// <summary>
        /// Update a booking trip's information.
        /// </summary>
        /// <param name="id">ID of the booking trip to update.</param>
        /// <param name="updateBookingTrip">Updated booking trip data.</param>
        /// <param name="tripId">ID of the associated trip.</param>
        public async Task<BookingTripDTO> UpdateBookingTrip(int id, UpdateBookingTripDTO updateBookingTrip, int tripId)
        {
            var bookingTrip = await _context.bookingTrips.FindAsync(id);
            var trip = await _context.Trips.FindAsync(tripId);

            if (bookingTrip != null && trip != null)
            {
                // Calculate the updated duration based on StartDate and EndDate
                int duration = (int)(updateBookingTrip.EndDate - updateBookingTrip.StartDate).TotalDays;

                // Calculate the cost based on the trip's cost
                decimal cost = trip.Cost * updateBookingTrip.NumberOfPersons;

                if (trip.Capacity >= (trip.Count - bookingTrip.NumberOfPersons + updateBookingTrip.NumberOfPersons))
                {
                    bookingTrip.NumberOfPersons = updateBookingTrip.NumberOfPersons;
                    bookingTrip.StartDate = updateBookingTrip.StartDate;
                    bookingTrip.EndDate = updateBookingTrip.EndDate;
                    bookingTrip.CostPerPerson = trip.Cost;
                    bookingTrip.Duration = duration;
                    bookingTrip.TotalPrice = cost;

                    trip.Count = trip.Count - bookingTrip.NumberOfPersons + updateBookingTrip.NumberOfPersons;

                    _context.Entry(bookingTrip).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    var updatedBookingTripDTO = await GetBookingTripById(id);
                    return updatedBookingTripDTO;
                }

                return null; // Capacity exceeded
            }

            return null; // Booking or trip does not exist
        }


        public async Task<BookingTripDTO> UpdateBookingTripByUser(int id, UpdateBookingTripDTO updateBookingTrip, int tripId)
        {
            var bookingTrip = await _context.bookingTrips.FindAsync(id);
            var trip = await _context.Trips.FindAsync(tripId);

            if (bookingTrip != null && trip != null)
            {
                // Calculate the updated duration based on StartDate and EndDate
                int duration = (int)(updateBookingTrip.EndDate - updateBookingTrip.StartDate).TotalDays;

                // Calculate the cost based on the trip's cost
                decimal cost = trip.Cost * updateBookingTrip.NumberOfPersons;

                if (trip.Capacity >= (trip.Count - bookingTrip.NumberOfPersons + updateBookingTrip.NumberOfPersons))
                {
                    bookingTrip.NumberOfPersons = updateBookingTrip.NumberOfPersons;
                    bookingTrip.StartDate = updateBookingTrip.StartDate;
                    bookingTrip.EndDate = updateBookingTrip.EndDate;
                    bookingTrip.Duration = duration;
                    bookingTrip.TotalPrice = updateBookingTrip.NumberOfPersons * trip.Cost;

                    trip.Count = trip.Count - bookingTrip.NumberOfPersons + updateBookingTrip.NumberOfPersons;

                    _context.Entry(bookingTrip).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    var updatedBookingTripDTO = await GetBookingTripById(id);
                    return updatedBookingTripDTO;
                }

                return null; // Capacity exceeded
            }

            return null; // Booking or trip does not exist
        }


        /// <summary>
        /// Delete a booking trip by its ID and associated trip ID.
        /// </summary>
        /// <param name="id">ID of the booking trip.</param>
        /// <param name="tripId">ID of the associated trip.</param>
        public async Task Delete(int id, int tripId)
        {
            var bookingTrip = await _context.bookingTrips.FindAsync(id);
            var trip = await _context.Trips.FindAsync(tripId);

            if (bookingTrip != null)
            {
                trip.Count -= bookingTrip.NumberOfPersons;

                _context.Entry<BookingTrip>(bookingTrip).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
        }
    }
}
