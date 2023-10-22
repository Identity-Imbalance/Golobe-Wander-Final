using Globe_Wander_Final.Models.DTOs;

namespace Globe_Wander_Final.Models.ViewModels
{
    public class RecomandedTripsAndTrip
    {
        public TripDTO trip {  get; set; }

        public List<TripDTO>? ListTrips { get; set; }
    }
}
