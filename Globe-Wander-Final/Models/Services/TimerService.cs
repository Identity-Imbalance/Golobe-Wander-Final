using Globe_Wander_Final.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Timers;
using static System.Formats.Asn1.AsnWriter;

namespace Globe_Wander_Final.Models.Services
{
    public class TimerService
    {
        
        private System.Timers.Timer cleanupTimer; // Timer for cleanup tasks
        private readonly IServiceProvider _serviceProvider;
        public TimerService( IServiceProvider serviceProvider)
        {

            _serviceProvider = serviceProvider;

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

            using (var scope = _serviceProvider.CreateScope())
            {
                var scopedContext = scope.ServiceProvider.GetRequiredService<GlobeWanderDbContext>();
                DateTime currentDate = DateTime.Now;

                // Get and delete bookings with past checkout dates from the scoped context
                var pastBookings = await scopedContext.BookingRooms
                    .Where(booking => booking.CheckOut < currentDate)
                    .ToListAsync();

                foreach (var booking in pastBookings)
                {
                    var hotelRoom = await scopedContext.HotelRooms.FindAsync(booking.HotelID, booking.RoomNumber);
                    if (hotelRoom != null)
                    {
                        hotelRoom.IsAvailable = true;
                    }
                    scopedContext.BookingRooms.Remove(booking);
                }

                await scopedContext.SaveChangesAsync();
            }
        }
    }
}
    

