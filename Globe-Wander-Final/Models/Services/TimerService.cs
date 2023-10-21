using Globe_Wander_Final.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Timers;

namespace Globe_Wander_Final.Models.Services
{
    public class TimerService
    {
        private readonly GlobeWanderDbContext _context;
        private System.Timers.Timer cleanupTimer; // Timer for cleanup tasks

        public TimerService(GlobeWanderDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
       
            // Initialize and start a timer to run the cleanup function every hour
            cleanupTimer = new System.Timers.Timer();
            cleanupTimer.Elapsed += CleanupBookings;
            cleanupTimer.Interval = TimeSpan.FromHours(1).TotalMilliseconds; // Set the interval to 1 hour
            cleanupTimer.AutoReset = true;
            cleanupTimer.Enabled = true;
        }

        public void CleanupBookings(object sender, ElapsedEventArgs e)
        {
            // This function will be called every hour to delete past bookings
            DeletePastBookings();
        }

        private async void DeletePastBookings()
        {
            DateTime currentDate = DateTime.Now;

            // Get and delete bookings with past checkout dates
            var pastBookings = await _context.BookingRooms
                .Where(booking => booking.CheckOut < currentDate)
                .ToListAsync();

            foreach (var booking in pastBookings)
            {
                var hotelRoom = await _context.HotelRooms.FindAsync(booking.HotelID, booking.RoomNumber);
                if (hotelRoom != null)
                {
                    hotelRoom.IsAvailable = true;
                }
                _context.BookingRooms.Remove(booking);
            }

            await _context.SaveChangesAsync();
        }
    }
}
