
using Globe_Wander_Final.Data;
using System.Threading;

namespace Globe_Wander_Final.Models.Services
{
    public class TimerService : IHostedService, IDisposable
    {
        private Timer _timer;
        private readonly IServiceScopeFactory _scopeFactory;

        public TimerService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(5));
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
              
                var context = scope.ServiceProvider.GetRequiredService<GlobeWanderDbContext>();

                var expiredBookings = context.BookingRooms.Where(b => b.CheckOut < DateTime.Now);
                context.BookingRooms.RemoveRange(expiredBookings);

                context.SaveChanges();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
    

