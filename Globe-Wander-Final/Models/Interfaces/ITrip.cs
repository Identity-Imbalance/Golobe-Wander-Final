using Globe_Wander_Final.Models.DTOs;

namespace Globe_Wander_Final.Models.Interfaces
{
    public interface ITrip
    {
        public Task<List<TripDTO>> GetAllTrips();

        public Task<TripDTO> GetTripByID(int id);

        public Task<TripDTO> CreateTrip(NewTripDTO trip);

        public Task<TripDTO> UpdateTrip(UpdateTripDTO trip, int id);

        public Task DeleteTrip(int id);
    }
}
