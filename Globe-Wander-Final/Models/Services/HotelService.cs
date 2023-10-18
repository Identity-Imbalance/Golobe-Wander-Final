using Globe_Wander_Final.Data;
using Globe_Wander_Final.Models.DTOs;
using Globe_Wander_Final.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Globe_Wander_Final.Models.Services
{
    /// <summary>
    /// Service implementation for managing hotels.
    /// </summary>
    public class HotelService : IHotel
    {


        private readonly GlobeWanderDbContext _context;

        public HotelService(GlobeWanderDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Create a new hotel.
        /// </summary>
        /// <param name="hotelDTO">Data for the new hotel.</param>
        public async Task<NewHotelDTO> CreateHotel(NewHotelDTO hotelDTO)
        {
            Hotel hotel = new Hotel()
            {
                Name = hotelDTO.Name,
                Description = hotelDTO.Description,
                TourSpotID = hotelDTO.TourSpotID
     
            };

            _context.Entry(hotel).State = EntityState.Added;
            await _context.SaveChangesAsync();

            hotelDTO.Id = hotel.Id;

            return hotelDTO;
        }

        /// <summary>
        /// Delete a hotel by its ID.
        /// </summary>
        /// <param name="id">ID of the hotel.</param>
        public async Task<Hotel> DeleteHotel(int id)

        {
            // Hotel hoteldto = await GetHotelId(id);
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel != null)
            {
                _context.Entry(hotel).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }



            return hotel;
        }

        /// <summary>
        /// Get a hotel by its ID.
        /// </summary>
        /// <param name="hotelId">ID of the hotel.</param>

        public async Task<HotelDTO> GetHotelId(int hotelId)
        {
            var hotelRooms = await _context.HotelRooms.Where(x => x.HotelID == hotelId).Select(v => new HotelRoomDTO
            {
                HotelID = v.HotelID,
                RoomID = v.RoomID,
                SquareFeet=v.SquareFeet,
                Bathrooms=v.Bathrooms,
                Beds=v.Beds,
                HotelRoomImages= _context.Images.Where(w=>v.HotelID == w.HotelId && v.RoomNumber == w.RoomNumber).Select(e => new Image
                {
                    Id=e.Id,
                    HotelId=e.HotelId,
                    RoomNumber=e.RoomNumber,
                    Path=e.Path,
                    
                }
                            ).ToList(),
                  
                Description=v.Description,
                IsAvailable = v.IsAvailable,
                RoomNumber = v.RoomNumber,
                PricePerDay = v.PricePerDay,
                Rooms = _context.Rooms.Select(r => new RoomDTO
                {
                    ID = r.ID,
                    Layout = r.Layout,
                    Name = r.Name,
                    RoomAmenities = _context.RoomAmenities.Where(I => I.RoomId == r.ID).Select(l => new RoomAmenity
                    {
                        Amenity = l.Amenity,
                        Room = l.Room,
                        AmenityId = l.AmenityId,
                        RoomId = l.RoomId,
                    }
                            ).ToList()
                }).Where(r => r.ID == v.RoomID).FirstOrDefault(),
                BookingRoom = _context.BookingRooms.Select(bk => new BookingRoomDTO
                {
                    ID = bk.ID,
                    HotelID = bk.HotelID,
                    Cost = bk.Cost,
                    RoomNumber = bk.RoomNumber,
                    TotalPrice = bk.TotalPrice,
                    Duration = bk.Duration,
                    Username = bk.Username
                }).Where(bk => bk.RoomNumber == v.RoomNumber).FirstOrDefault()

            }).ToListAsync();

            HotelDTO? hotel = await _context.Hotels.Where(x => x.Id == hotelId).Include(v=>v.HotelRoom).Select(b => new HotelDTO
            {
                Id = b.Id,
                Name = b.Name,
                Location = b.Location,
                StarRate = b.StarRate,
                HotelFacilities = _context.HotelFacilities.Where(q => q.HotelId == b.Id).Select(k => new HotelFacility
                {
                    Id = k.Id,
                    Facility = k.Facility,
                    FacilityId = k.FacilityId,
                    Hotel = k.Hotel,
                    HotelId = b.Id,
                }).ToList(),

                HotelImages = _context.Images.Where(w => b.Id == w.HotelId &&  w.RoomNumber == null).Select(e => new Image
                {
                    Id = e.Id,
                    HotelId = e.HotelId,

                    Path = e.Path,

                }
                            ).ToList(),

                Description = b.Description,
                TourSpotID = b.TourSpotID,
                HotelRoom = hotelRooms
            }).FirstOrDefaultAsync();
            ;
            return hotel;

        }

        /// <summary>
        /// Get a list of all hotels.
        /// </summary>
        public async Task<List<HotelDTO>> GetAllHotels()
        {


            List<HotelDTO> hotel = await _context.Hotels.Select(b => new HotelDTO
            {
                Id = b.Id,
                Name = b.Name,
                Location=b.Location,
                StarRate = b.StarRate,

                HotelImages = _context.Images.Where(w => b.Id == w.HotelId && w.RoomNumber == null).Select(e => new Image
                {
                    Id = e.Id,
                    HotelId = e.HotelId,

                    Path = e.Path,

                }
                            ).ToList(),
                HotelFacilities =_context.HotelFacilities.Where(q=>q.HotelId==b.Id).Select(k=> new HotelFacility
               {Id=k.Id,
                   Facility=k.Facility,
                    FacilityId=k.FacilityId,
                    Hotel=k.Hotel,
                    HotelId=b.Id,
               }).ToList(),
                Description = b.Description,
                TourSpotID = b.TourSpotID,
                HotelRoom = _context.HotelRooms.Where(x => x.HotelID == b.Id).Select(v => new HotelRoomDTO
                {
                    HotelID = v.HotelID,
                    RoomID = v.RoomID,
                    IsAvailable = v.IsAvailable,
                    RoomNumber = v.RoomNumber,
                    Bathrooms = v.Bathrooms,
                    Description = v.Description,
                    Beds = v.Beds,
                    SquareFeet = v.SquareFeet,
                    PricePerDay = v.PricePerDay,
                    HotelRoomImages = _context.Images.Where(w => v.HotelID == w.HotelId && v.RoomNumber == w.RoomNumber).Select(e => new Image
                    {
                        Id = e.Id,
                        HotelId = e.HotelId,
                        RoomNumber = e.RoomNumber,
                        Path = e.Path,

                    }
                            ).ToList(),
                    Rooms = _context.Rooms.Select(r => new RoomDTO
                    {
                        ID = r.ID,
                        Layout = r.Layout,
                        Name = r.Name,
                        RoomAmenities = _context.RoomAmenities.Where(I=>I.RoomId==r.ID).Select(l=> new RoomAmenity
                        { 
                            Amenity = l.Amenity,
                            Room=l.Room,
                            AmenityId = l.AmenityId,
                            RoomId = l.RoomId,
                        }
                            ).ToList(),
                    }).Where(r => r.ID == v.RoomID).FirstOrDefault(),
                    BookingRoom = _context.BookingRooms.Select(bk => new BookingRoomDTO
                    {
                        ID = bk.ID,
                        HotelID = bk.HotelID,
                        Cost = bk.Cost,
                        RoomNumber = bk.RoomNumber,
                        TotalPrice = bk.TotalPrice,
                        Duration = bk.Duration,
                        Username = bk.Username
                    }).Where(bk => bk.RoomNumber == v.RoomNumber).FirstOrDefault()


                }).ToList()
            }).ToListAsync();


            return hotel;
        }

        /// <summary>
        /// Update a hotel's information.
        /// </summary>
        /// <param name="id">ID of the hotel.</param>
        /// <param name="updatedHotel">Updated hotel data.</param>
        public async Task<HotelDTO> UpdateHotel(int id, HotelDTO updatedHotel)
        {
            Hotel? hotel = await _context.Hotels.FindAsync(id);

            if (hotel != null)
            {

                hotel.Name = updatedHotel.Name;
                hotel.Description = updatedHotel.Description;
                hotel.Location= updatedHotel.Location;
                hotel.StarRate= updatedHotel.StarRate;
               
                _context.Entry(hotel).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                updatedHotel.Id = id;
                updatedHotel.TourSpotID = hotel.TourSpotID;

                return updatedHotel;
            }
            return null;
        }

        public async Task<List<AnonymousHotelDTO>> AnonymousHotelDTOs()
        {
            return await _context.Hotels.Select(x => new AnonymousHotelDTO
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            }).ToListAsync();
        }
    }
}
