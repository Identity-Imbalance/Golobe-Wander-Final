﻿using Globe_Wander_Final.Data;
using Globe_Wander_Final.Models.DTOs;
using Globe_Wander_Final.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Globe_Wander_Final.Models.Services
{
    /// <summary>
    /// Service for managing tour spots.
    /// </summary>
    public class TourSpotService : ITourSpot
    {
        private readonly GlobeWanderDbContext _context;

        private readonly IAddImage _upload;

        public TourSpotService(GlobeWanderDbContext context, IAddImage upload)
        {
            _context = context;
            _upload = upload;
        }

        /// <summary>
        /// Create a new tour spot.
        /// </summary>
        /// <param name="tourSpot">Tour spot data.</param>
        public async Task<TourSpotDTO> CreateTourSpot(newTourSpotDTO tourSpot, IFormFile file)
        {
            var newTourSpot = new TourSpot()
            {
                ID = tourSpot.ID,
                Name = tourSpot.Name,
                Country = tourSpot.Country,
                City = tourSpot.City,
                Description = tourSpot.Description,
                Category = tourSpot.Category,
                PhoneNumber = tourSpot.PhoneNumber,
            };
            _context.Entry<TourSpot>(newTourSpot).State = EntityState.Added;
            if (file != null)
            {
                await _upload.UploadImage(file, newTourSpot);
            }
            await _context.SaveChangesAsync();
            var tourSpotDTO = await GetSpotById(newTourSpot.ID);
            tourSpot.ID = newTourSpot.ID;

            return tourSpotDTO;
        }

        /// <summary>
        /// Delete a tour spot by ID.
        /// </summary>
        /// <param name="id">ID of the tour spot to be deleted.</param>
        public async Task DeleteTourSpot(int id)
        {
            TourSpot tourSpotToDelete = await _context.TourSpots.FindAsync(id);

            _context.Entry<TourSpot>(tourSpotToDelete).State = EntityState.Deleted;

            await _context.SaveChangesAsync();

        }

        /// <summary>
        /// Get a list of all tour spots.
        /// </summary>
        public async Task<List<TourSpotDTO>> GetAllTourSpots()
        {

            var tourSpots = await _context.TourSpots.Select(
                tours => new TourSpotDTO
                {
                    ID = tours.ID,
                    Name = tours.Name,
                    Country = tours.Country,
                    City = tours.City,
                    Description = tours.Description,
                    Category = tours.Category,
                    PhoneNumber = tours.PhoneNumber,
                    Img = tours.Img,
                    Hotels = tours.Hotels.Select(hotels => new HotelDTO
                    {
                        TourSpotID = hotels.TourSpotID,
                        Id = hotels.Id,
                        Name = hotels.Name,
                        Description = hotels.Description,
                        HotelRoom = hotels.HotelRoom.Select(hrooms => new HotelRoomDTO
                        {
                            RoomNumber = hrooms.RoomNumber,
                            HotelID = hrooms.HotelID,
                            RoomID = hrooms.RoomID,
                            PricePerDay = hrooms.PricePerDay,
                            IsAvailable = hrooms.IsAvailable,
                            Rooms = hrooms.Rooms != null ? new RoomDTO
                            {
                                ID = hrooms.Rooms.ID,
                                Name = hrooms.Rooms.Name,
                                Layout = hrooms.Rooms.Layout

                            } : null,
                            BookingRoom = hrooms.BookingRoom != null ? new BookingRoomDTO
                            {
                                ID = hrooms.BookingRoom.ID,
                                RoomNumber = hrooms.BookingRoom.RoomNumber,
                                HotelID = hrooms.BookingRoom.HotelID,
                                Cost = hrooms.BookingRoom.Cost,
                                Duration = hrooms.BookingRoom.Duration,
                                TotalPrice = hrooms.BookingRoom.TotalPrice,
                                Username = hrooms.BookingRoom.Username
                            } : null
                        }).ToList(),
                    }).ToList(),
                    Trips = tours.Trips
                    .Where(x => x.TourSpotID == tours.ID)
                    .Select(trips => new TripDTO
                    {
                        Id = trips.Id,
                        Name = trips.Name,
                        Description = trips.Description,
                        Cost = trips.Cost,
                        Activity = trips.Activity,
                        StartDate = trips.StartDate,
                        EndDate = trips.EndDate,
                        Capacity = trips.Capacity,
                        Count = trips.Count,
                        TourSpotID = trips.TourSpotID,
                        BookingTrips = trips.BookingTrips.Select(bt => new BookingTripDTO
                        {
                            ID = bt.ID,
                            TripID = bt.TripID,
                            NumberOfPersons = bt.NumberOfPersons,
                            CostPerPerson = bt.CostPerPerson,
                            TotalPrice = bt.TotalPrice,
                            Username = bt.Username
                        }).ToList(),
                        TripImages = _context.Images.Where(w => trips.Id == w.TripId).Select(e => new Image
                        {
                            Id = e.Id,
                            TripId = e.TripId,
                            Path = e.Path,

                        }
                            ).ToList(),
                        Rates = trips.Rates.Select(r => new RateDTO
                        {
                            ID = r.ID,
                            TripID = r.TripID,
                            Comments = r.Comments,
                            Rating = r.Rating,
                            Username = r.Username
                        }).ToList()
                    })
                    .ToList()

                }
                ).ToListAsync();
            return tourSpots;

        }
        /// <summary>
        /// get Tour spot location to use in the collection of the hotels it will be temp
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<string> GetLocationByTourSptID(int id)
        {
            var tour = await _context.TourSpots.FindAsync(id);

            string location = tour.City + ", " + tour.Country;

            return location;
        }

        public async Task<List<TrendTourSpotDTO>> GetMostVisitedTourSpots()
        {
            var tourSpots = await _context.TourSpots.Select(
                tours => new TrendTourSpotDTO
                {
                    ID = tours.ID,
                    Name = tours.Name,
                    Country = tours.Country,
                    City = tours.City,
                    Description = tours.Description,
                    Category = tours.Category,
                    PhoneNumber = tours.PhoneNumber,
                    Hotels = tours.Hotels.Select(hotels => new TrendHotelDTO
                    {
                        //TourSpotID = hotels.TourSpotID,
                        Id = hotels.Id,
                        Name = hotels.Name,
                        Description = hotels.Description,
                        HotelRoom = hotels.HotelRoom.Select(hrooms => new TrendHotelRoomDTO
                        {
                            RoomNumber = hrooms.RoomNumber,
                            HotelID = hrooms.HotelID,
                            RoomID = hrooms.RoomID,
                            PricePerDay = hrooms.PricePerDay,
                            IsAvailable = hrooms.IsAvailable,
                            //Rooms = hrooms.Rooms != null ? new RoomDTO
                            //{
                            //    ID = hrooms.Rooms.ID,
                            //    Name = hrooms.Rooms.Name,
                            //    Layout = hrooms.Rooms.Layout

                            //} : null,
                            //BookingRoom = hrooms.BookingRoom != null ? new BookingRoomDTO
                            //{
                            //    ID = hrooms.BookingRoom.ID,
                            //    RoomNumber = hrooms.BookingRoom.RoomNumber,
                            //    HotelID = hrooms.BookingRoom.HotelID,
                            //    Cost = hrooms.BookingRoom.Cost,
                            //    Duration = hrooms.BookingRoom.Duration,
                            //    TotalPrice = hrooms.BookingRoom.TotalPrice,
                            //    Username = hrooms.BookingRoom.Username
                            //} : null
                        }).ToList(),
                    }).ToList(),
                    Trips = tours.Trips
                    .Where(x => x.TourSpotID == tours.ID)
                    .Select(trips => new TrendTripDTO
                    {
                        Id = trips.Id,
                        Name = trips.Name,
                        Description = trips.Description,
                        Cost = trips.Cost,
                        Activity = trips.Activity,
                        StartDate = trips.StartDate,
                        EndDate = trips.EndDate,
                        Capacity = trips.Capacity,
                        Count = trips.Count,
                        //TourSpotID = trips.TourSpotID,
                        //BookingTrips = trips.BookingTrips.Select(bt => new BookingTripDTO
                        //{
                        //    ID = bt.ID,
                        //    TripID = bt.TripID,
                        //    NumberOfPersons = bt.NumberOfPersons,
                        //    CostPerPerson = bt.CostPerPerson,
                        //    TotalPrice = bt.TotalPrice,
                        //    Duration = bt.Duration,
                        //    Username = bt.Username
                        //}).ToList(),
                        //Rates = trips.Rates.Select(r => new RateDTO
                        //{
                        //    ID = r.ID,
                        //    TripID = r.TripID,
                        //    Comments = r.Comments,
                        //    Rating = r.Rating,
                        //    Username = r.Username
                        //}).ToList()
                    })
                    .ToList()

                }
                ).OrderByDescending(t => t.Trips.Sum(t => t.Count))
                .ToListAsync();
            return tourSpots;
        }

        /// <summary>
        /// Get tour spot data by ID.
        /// </summary>
        /// <param name="id">ID of the tour spot.</param>

        public async Task<TourSpotDTO> GetSpotById(int id)
        {
            TourSpotDTO? tourSpot = await _context.TourSpots
                .Where(x => x.ID == id)
                .Select(
                tours => new TourSpotDTO
                {
                    ID = tours.ID,
                    Name = tours.Name,
                    Country = tours.Country,
                    City = tours.City,
                    Description = tours.Description,
                    Category = tours.Category,
                    PhoneNumber = tours.PhoneNumber,
                    Img = tours.Img,
                    Hotels = tours.Hotels.Select(b => new HotelDTO
                    {
                        Id = b.Id,
                        Name = b.Name,
                        Location = b.Location,
                        StarRate = b.StarRate,

                        HotelImages = _context.Images.Where(w => b.Id == w.HotelId && w.RoomNumber == null).Select(e => new Image
                        {
                            Id = e.Id,
                            HotelId = e.HotelId,

                            Path = e.Path,

                        }
                            ).ToList(),
                        HotelFacilities = _context.HotelFacilities.Where(q => q.HotelId == b.Id).Select(k => new HotelFacility
                        {
                            Id = k.Id,
                            Facility = k.Facility,
                            FacilityId = k.FacilityId,
                            Hotel = k.Hotel,
                            HotelId = b.Id,
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
                                RoomAmenities = _context.RoomAmenities.Where(I => I.RoomId == r.ID).Select(l => new RoomAmenity
                                {
                                    Amenity = l.Amenity,
                                    Room = l.Room,
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


                        }).ToList(),

                    }).ToList(),
                    Trips = tours.Trips
                    .Where(x => x.TourSpotID == tours.ID)
                    .Select(trips => new TripDTO
                    {
                        Id = trips.Id,
                        Name = trips.Name,
                        Description = trips.Description,    
                        Cost = trips.Cost,
                        Activity = trips.Activity,
                        StartDate = trips.StartDate,
                        EndDate = trips.EndDate,
                        Capacity = trips.Capacity,
                        Count = trips.Count,
                        TourSpotID = trips.TourSpotID,
                        TripImages = _context.Images.Where(w => trips.Id == w.TripId).Select(e => new Image
                        {
                            Id = e.Id,
                            TripId = e.TripId,
                            Path = e.Path,

                        }
                            ).ToList(),
                        BookingTrips = trips.BookingTrips.Select(bt => new BookingTripDTO
                        {
                            ID = bt.ID,
                            TripID = bt.TripID,
                            NumberOfPersons = bt.NumberOfPersons,
                            CostPerPerson = bt.CostPerPerson,
                            TotalPrice = bt.TotalPrice,
                            Username = bt.Username
                        }).ToList(),
                     
                        Rates = trips.Rates.Select(r => new RateDTO
                        {
                            ID = r.ID,
                            TripID = r.TripID,
                            Comments = r.Comments,
                            Rating = r.Rating,
                            Username = r.Username
                        }).ToList()
                    }).ToList()

                }
                ).FirstOrDefaultAsync();



            return tourSpot;
        }

        /// <summary>
        /// Update tour spot data by ID.
        /// </summary>
        /// <param name="tourSpot">Updated tour spot data.</param>
        /// <param name="id">ID of the tour spot to be updated.</param>
        public async Task<TourSpotDTO> UpdateTourSpot(newTourSpotDTO tourSpot, int id, IFormFile file)
        {
            var tourSpotRecord = await _context.TourSpots.FindAsync(id);

            if (tourSpotRecord != null)
            {
                tourSpotRecord.ID = id;
                tourSpotRecord.Name = tourSpot.Name;
                tourSpotRecord.Country = tourSpot.Country;
                tourSpotRecord.City = tourSpot.City;
                tourSpotRecord.Description = tourSpot.Description;
                tourSpotRecord.Category = tourSpot.Category;
                tourSpotRecord.PhoneNumber = tourSpot.PhoneNumber;

                _context.Entry(tourSpotRecord).State = EntityState.Modified;
                if (file != null)
                {

               await _upload.UploadImage(file, tourSpotRecord);
                }

                await _context.SaveChangesAsync();


            }
            tourSpot.ID = id;
            var updateTour = await GetSpotById(tourSpot.ID);
            return updateTour;

        }
    }
}