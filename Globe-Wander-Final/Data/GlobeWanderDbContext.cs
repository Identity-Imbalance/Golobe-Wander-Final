using Globe_Wander_Final.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Stripe;
using System.Reflection.Emit;

namespace Globe_Wander_Final.Data
{
    public class GlobeWanderDbContext : IdentityDbContext<ApplicationUser>
    {
        public GlobeWanderDbContext(DbContextOptions option) : base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TourSpot>().HasData(
    new TourSpot() { ID = 1, Name = "Petra", Country = "Jordan", City = "Petra", Description = "a place before thousands years", Category = Category.Historical, PhoneNumber = "078885423", Img = "https://images.pexels.com/photos/1631665/pexels-photo-1631665.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
    new TourSpot() { ID = 2, Name = "Jerash", Country = "Jordan", City = "Jerash", Description = "A historical place that the Romanian civilization build before thousands years.", Category = Category.Historical, PhoneNumber = "088782215", Img = "https://c0.wallpaperflare.com/preview/705/707/822/jordan-jerash-oval-plaza-market.jpg" },
    new TourSpot() { ID = 3, Name = "Um Qais", Country = "Jordan", City = "Irbid", Description = "A historical place that the Romanian civilization build before thousands years. In the north of Jordan", Category = Category.Historical, PhoneNumber = "0788442521", Img = "https://followinghadrianphotographycom.files.wordpress.com/2020/09/34509636386_2139ee3bc1_k.jpg?w=1075&h=712" },
    new TourSpot() { ID = 4, Name = "Wadi Rum", Country = "Jordan", City = "Aqaba", Description = "A spectacular desert in southern Jordan.", Category = Category.Natural, PhoneNumber = "0788555444", Img = "https://c4.wallpaperflare.com/wallpaper/774/140/860/nature-landscape-sand-desert-dunes-hd-wallpaper-preview.jpg" },
    new TourSpot() { ID = 5, Name = "Ajloun Castle", Country = "Jordan", City = "Ajloun", Description = "A 12th-century Muslim castle in northern Jordan.", Category = Category.Historical, PhoneNumber = "0799111122", Img = "https://as1.ftcdn.net/v2/jpg/02/49/78/08/1000_F_249780853_qBrIwoai4WNGR0OSx4I6A3EZZ47cUN5B.jpg" },
    new TourSpot() { ID = 6, Name = "Dead Sea", Country = "Jordan", City = "Amman", Description = "The lowest point on Earth and famous for its high salt content.", Category = Category.Natural, PhoneNumber = "0777888999", Img = "https://c4.wallpaperflare.com/wallpaper/884/827/830/dead-sea-coast-white-salt-blue-sea-wallpaper-preview.jpg" },
    new TourSpot() { ID = 7, Name = "Aqaba Beach", Country = "Jordan", City = "Aqaba", Description = "Beautiful beaches along the Red Sea.", Category = Category.Natural, PhoneNumber = "0799777666", Img = "https://wallpapers.com/images/high/aqaba-jordan-shoreline-y69cto406g6r0i5c.webp" },
    new TourSpot() { ID = 8, Name = "Wadi Al-Mujib", Country = "Jordan", City = "Madaba", Description = "Ancient hilltop fortress where John the Baptist was imprisoned.", Category = Category.Historical, PhoneNumber = "0777666555", Img = "https://storage.kempinski.com/cdn-cgi/image/w=960,f=auto,g=auto,fit=scale-down/ki-cms-prod/images/4/5/5/3/313554-1-eng-GB/9e96e4717f7a-74342124_4K.jpg" },
    new TourSpot() { ID = 9, Name = "Dana Biosphere Reserve", Country = "Jordan", City = "Tafilah", Description = "A diverse ecological system in southern Jordan.", Category = Category.Natural, PhoneNumber = "0799888777", Img = "https://www.jordanbesttours.com/images/dana/jordan_nature_reserves_dana_full.jpg" }
    );
            modelBuilder.Entity<Trip>().HasData(

                new Trip() { Id = 1, TourSpotID = 1, Name = "Petra ride", Cost = 20, Capacity = 30, Count = 0, Activity = "walking", StartDate = DateTime.Now, EndDate = DateTime.UtcNow, Description = "trip start at 8 am and going from Amman to Petra" },
                 new Trip() { Id = 2, TourSpotID = 1, Name = "Jerash ride", Cost = 30, Capacity = 22, Count = 0, Activity = "visiting", StartDate = DateTime.Now, EndDate = DateTime.UtcNow, Description = "Amman to Jerash with a trip manager who can speak many languages" },
                     new Trip() { Id = 3, TourSpotID = 1, Name = "Um-Qais ride", Cost = 40, Capacity = 40, Count = 0, Activity = "climbing", StartDate = DateTime.Now, EndDate = DateTime.UtcNow, Description = "Amman to Irbid with a trip manager who can speak many languages" },

                new Trip() { Id = 4, TourSpotID = 2, Name = "Wadi Rum Adventure", Cost = 50, Capacity = 20, Count = 0, Activity = "desert safari", StartDate = DateTime.Now, EndDate = DateTime.UtcNow, Description = "Explore the breathtaking Wadi Rum desert in Jordan." },
                 new Trip() { Id = 5, TourSpotID = 2, Name = "Dead Sea Relaxation", Cost = 25, Capacity = 15, Count = 0, Activity = "swimming and mud baths", StartDate = DateTime.Now, EndDate = DateTime.UtcNow, Description = "Relax at the world-famous Dead Sea and experience its healing properties." },
                     new Trip() { Id = 6, TourSpotID = 2, Name = "Aqaba Diving Expedition", Cost = 60, Capacity = 10, Count = 0, Activity = "scuba diving", StartDate = DateTime.Now, EndDate = DateTime.UtcNow, Description = "Discover the vibrant marine life of the Red Sea in Aqaba." },

                new Trip() { Id = 7, TourSpotID = 3, Name = "Amman City Tour", Cost = 15, Capacity = 25, Count = 0, Activity = "sightseeing", StartDate = DateTime.Now, EndDate = DateTime.UtcNow, Description = "Explore the historical and cultural landmarks of Amman." },
                 new Trip() { Id = 8, TourSpotID = 3, Name = "Dana Biosphere Reserve Hike", Cost = 35, Capacity = 12, Count = 0, Activity = "hiking", StartDate = DateTime.Now, EndDate = DateTime.UtcNow, Description = "Trek through the stunning Dana Biosphere Reserve." },
                     new Trip() { Id = 9, TourSpotID = 3, Name = "Wadi Mujib Canyoning", Cost = 45, Capacity = 18, Count = 0, Activity = "canyoning", StartDate = DateTime.Now, EndDate = DateTime.UtcNow, Description = "Experience the adventure of canyoning in Wadi Mujib." },

                new Trip() { Id = 10, TourSpotID = 4, Name = "Ma'in Hot Springs Visit", Cost = 20, Capacity = 30, Count = 0, Activity = "relaxation", StartDate = DateTime.Now, EndDate = DateTime.UtcNow, Description = "Relax in the soothing hot springs of Ma'in." },
                 new Trip() { Id = 11, TourSpotID = 4, Name = "Kerak Castle Tour", Cost = 25, Capacity = 20, Count = 0, Activity = "historical tour", StartDate = DateTime.Now, EndDate = DateTime.UtcNow, Description = "Explore the historic Kerak Castle in Jordan." },
                     new Trip() { Id = 12, TourSpotID = 4, Name = "Ajloun Forest Reserve Trek", Cost = 30, Capacity = 15, Count = 0, Activity = "nature walk", StartDate = DateTime.Now, EndDate = DateTime.UtcNow, Description = "Take a nature walk in the Ajloun Forest Reserve." },

                new Trip() { Id = 13, TourSpotID = 4, Name = "Amman Culinary Tour", Cost = 40, Capacity = 12, Count = 0, Activity = "food tasting", StartDate = DateTime.Now, EndDate = DateTime.UtcNow, Description = "Indulge in a culinary journey through Amman's cuisine." },
                 new Trip() { Id = 14, TourSpotID = 4, Name = "Mosaic City Madaba", Cost = 20, Capacity = 25, Count = 0, Activity = "mosaic art", StartDate = DateTime.Now, EndDate = DateTime.UtcNow, Description = "Discover the mosaic art of Madaba." },
                     new Trip() { Id = 15, TourSpotID = 4, Name = "Ajloun Castle Exploration", Cost = 30, Capacity = 18, Count = 0, Activity = "historical tour", StartDate = DateTime.Now, EndDate = DateTime.UtcNow, Description = "Explore the historic Ajloun Castle." },

                new Trip() { Id = 16, TourSpotID = 5, Name = "Aqaba Beach Getaway", Cost = 55, Capacity = 20, Count = 0, Activity = "beach relaxation", StartDate = DateTime.Now, EndDate = DateTime.UtcNow, Description = "Relax on the beautiful beaches of Aqaba." },
                 new Trip() { Id = 17, TourSpotID = 5, Name = "Aqaba Snorkeling Adventure", Cost = 40, Capacity = 15, Count = 0, Activity = "snorkeling", StartDate = DateTime.Now, EndDate = DateTime.UtcNow, Description = "Explore the underwater world of the Red Sea through snorkeling in Aqaba." },
                     new Trip() { Id = 18, TourSpotID = 5, Name = "Aqaba Glass-Bottom Boat Tour", Cost = 30, Capacity = 25, Count = 0, Activity = "boat tour", StartDate = DateTime.Now, EndDate = DateTime.UtcNow, Description = "View marine life through a glass-bottom boat tour in Aqaba." },

                new Trip() { Id = 19, TourSpotID = 6, Name = "Aqaba Desert Jeep Safari", Cost = 45, Capacity = 12, Count = 0, Activity = "desert adventure", StartDate = DateTime.Now, EndDate = DateTime.UtcNow, Description = "Embark on an exciting jeep safari in the Aqaba desert." },
                 new Trip() { Id = 20, TourSpotID =6, Name = "Aqaba Nightlife Tour", Cost = 25, Capacity = 20, Count = 0, Activity = "nightclub hopping", StartDate = DateTime.Now, EndDate = DateTime.UtcNow, Description = "Experience the vibrant nightlife of Aqaba." },
                     new Trip() { Id = 21, TourSpotID = 6, Name = "Pyramids of Giza Tour", Cost = 60, Capacity = 15, Count = 0, Activity = "historical tour", StartDate = DateTime.Now, EndDate = DateTime.UtcNow, Description = "Explore the iconic Pyramids of Giza in Egypt." },

                new Trip() { Id = 22, TourSpotID = 7, Name = "Broadway Show Experience", Cost = 60, Capacity = 18, Count = 0, Activity = "theater", StartDate = DateTime.Now, EndDate = DateTime.UtcNow, Description = "Attend a Broadway show in the heart of New York City." },
                    new Trip() { Id = 23, TourSpotID = 7, Name = "Museum Mile Tour", Cost = 30, Capacity = 20, Count = 0, Activity = "museum visit", StartDate = DateTime.Now, EndDate = DateTime.UtcNow, Description = "Explore the museums along Museum Mile." },
                        new Trip() { Id = 24, TourSpotID = 7, Name = "Brooklyn Bridge Walk", Cost = 20, Capacity = 35, Count = 0, Activity = "walking tour", StartDate = DateTime.Now, EndDate = DateTime.UtcNow, Description = "Take a scenic walk across the historic Brooklyn Bridge." },
    
                new Trip() { Id = 25, TourSpotID = 8, Name = "Empire State Building Observation Deck", Cost = 35, Capacity = 30, Count = 0, Activity = "sightseeing", StartDate = DateTime.Now, EndDate = DateTime.UtcNow, Description = "Enjoy panoramic views from the Empire State Building." },
                    new Trip() { Id = 26, TourSpotID = 8, Name = "Hudson River Boat Tour", Cost = 45, Capacity = 25, Count = 0, Activity = "boat tour", StartDate = DateTime.Now, EndDate = DateTime.UtcNow, Description = "Cruise along the Hudson River and see Manhattan's skyline." },
                        new Trip() { Id = 27, TourSpotID = 8, Name = "Ubud Cultural Experience", Cost = 45, Capacity = 20, Count = 0, Activity = "cultural tour", StartDate = DateTime.Now, EndDate = DateTime.UtcNow, Description = "Immerse in the rich culture of Ubud, Bali." },

    new Trip() { Id = 28, TourSpotID = 9, Name = "Red Sea Adventure", Cost = 60, Capacity = 30, Count = 0, Activity = "snorkeling", StartDate = DateTime.Now, EndDate = DateTime.UtcNow, Description = "Explore the vibrant marine life of the Red Sea in Aqaba" },
    new Trip() { Id = 29, TourSpotID = 9, Name = "Desert Safari", Cost = 50, Capacity = 20, Count = 0, Activity = "off-roading", StartDate = DateTime.Now, EndDate = DateTime.UtcNow, Description = "Experience the thrill of a desert adventure in Aqaba" },
    new Trip() { Id = 30, TourSpotID = 9, Name = "Historical Dive", Cost = 70, Capacity = 15, Count = 0, Activity = "scuba diving", StartDate = DateTime.Now, EndDate = DateTime.UtcNow, Description = "Discover submerged historical sites in the Red Sea" }
                );


            modelBuilder.Entity<Image>().HasData(
            new Image { Id = 1, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip1.jpg", TripId = 1 },
              new Image { Id = 2, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip2.jpg", TripId = 2 },
                 new Image { Id = 3, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip3.jpg", TripId = 3 },
                    new Image { Id = 4, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip4.png", TripId = 4 },
                        new Image { Id = 5, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip5.jpg", TripId = 5 },
                            new Image { Id = 6, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip6.jpg", TripId = 6 },

                    new Image { Id = 7, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip7.png", TripId = 7 },
                      new Image { Id = 8, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip8.jpg", TripId = 8 },
                         new Image { Id = 9, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip9.jpg", TripId = 9 },
                            new Image { Id = 10, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip10.jpg", TripId = 10 },
                                new Image { Id = 11, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip30.jpg", TripId = 11 },
                                    new Image { Id = 12, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip31.jpg", TripId = 12 },

                    new Image { Id = 13, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip32.jpg", TripId = 13 },
                      new Image { Id = 14, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip9.jpg", TripId = 14 },
                         new Image { Id = 15, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip9.jpg", TripId = 15 },
                            new Image { Id = 16, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip1.jpg", TripId = 16 },
                                new Image { Id = 17, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip10.jpg", TripId = 17 },
                                    new Image { Id = 18, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip5.jpg", TripId = 18 },

                    new Image { Id = 19, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip1.jpg", TripId = 19 },
                      new Image { Id = 20, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip9.jpg", TripId = 20 },
                         new Image { Id = 21, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip10.jpg", TripId = 21 },
                            new Image { Id = 22, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip9.jpg", TripId = 22 },
                                new Image { Id = 23, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip1.jpg", TripId = 23 },
                                    new Image { Id = 24, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip10.jpg", TripId = 24 },

                    new Image { Id = 25, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip7.png", TripId = 25 },
                      new Image { Id = 26, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip10.jpg", TripId = 26 },
                         new Image { Id = 27, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip1.jpg", TripId = 27 },
                         new Image { Id = 28, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip7.png", TripId = 28 },
                      new Image { Id = 29, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip10.jpg", TripId = 29 },
                         new Image { Id = 30, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip1.jpg", TripId = 30 }



);

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel() { Id = 1, TourSpotID = 1, Name = "Paradise",Location="petra",StarRate=4, Description = "A unique hotel that you can't find in this place" },
                new Hotel() { Id = 2, TourSpotID = 2, Name = "Wander ", Location = "petra", StarRate = 4, Description = "A unique hotel that you can't find in this place" },
                new Hotel() { Id = 3, TourSpotID = 3, Name = "Amazing", Location = "petra", StarRate = 4, Description = "A unique hotel that y    ou can't find in this place" }
            );
            modelBuilder.Entity<HotelRoom>().HasData(
    new HotelRoom() { RoomNumber = 101, HotelID = 1, RoomID = 1, Description="CLEAN" ,SquareFeet=250,Bathrooms=2,Beds=3, PricePerDay = 100, IsAvailable = true },
    new HotelRoom() { RoomNumber = 102, HotelID = 1, RoomID = 2, Description = "CLEAN", SquareFeet = 250, Bathrooms = 2, Beds = 3, PricePerDay = 150, IsAvailable = true },
    new HotelRoom() { RoomNumber = 201, HotelID = 2, RoomID = 1, Description = "CLEAN", SquareFeet = 250, Bathrooms = 2, Beds = 3, PricePerDay = 120, IsAvailable = false }
);

             
        modelBuilder.Entity<Amenity>().HasData(
                new Amenity() { Id = 1, Name = "Free Wi-Fi" },
                new Amenity() { Id = 2, Name = "TV" },
                new Amenity() { Id = 3, Name = "Air conditioning" }
            );
            modelBuilder.Entity<RoomAmenity>().HasData(
    new RoomAmenity() { Id = 1, RoomId = 1, AmenityId = 1 },
    new RoomAmenity() { Id = 2, RoomId = 1, AmenityId = 2 },
    new RoomAmenity() { Id = 3, RoomId = 2, AmenityId = 3 },
    new RoomAmenity() { Id = 4, RoomId = 3, AmenityId = 1 }
);


            modelBuilder.Entity<Facility>().HasData(
                    new Facility() { Id = 1, Name = "swimingpool11111" },
                    new Facility() { Id = 2, Name = "swimingpool22222" },
                    new Facility() { Id = 3, Name = "swimingpool33333" }
                );
            modelBuilder.Entity<HotelFacility>().HasData(
    new HotelFacility() { Id = 1, FacilityId = 1, HotelId = 1 },
    new HotelFacility() { Id = 2, FacilityId = 1, HotelId = 2 },
    new HotelFacility() { Id = 3, FacilityId = 2, HotelId = 3 },
    new HotelFacility() { Id = 4, FacilityId = 3, HotelId = 1 }
);



            modelBuilder.Entity<Room>().HasData(
                new Room()
                {
                    ID = 1,
                    Name = "Small Room",
                    Layout = Layout.OneBed
                },
                new Room()
                {
                    ID = 2,
                    Name = "Suite Room",
                    Layout = Layout.TwoBed
                }
                ,
                new Room()
                {
                    ID = 3,
                    Name = "Studio room",
                    Layout = Layout.Studio
                }
            );

          
            modelBuilder.Entity<HotelRoom>().HasKey(
                 hotelRooms => new
                 {
                     hotelRooms.HotelID,
                     hotelRooms.RoomNumber
                 }
            );

            modelBuilder.Entity<HotelRoom>()
                .HasOne(b => b.BookingRoom)  // BookingRoom references HotelRoom
                .WithOne(h => h.HotelRooms) // HotelRoom references BookingRoom
                .HasForeignKey<BookingRoom>(h => new { h.HotelID, h.RoomNumber })
                .OnDelete(DeleteBehavior.NoAction);



            // Seed Users
            var hasher = new PasswordHasher<ApplicationUser>();
            var Admin = new ApplicationUser
            {
                Id = "1",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "adminUser@example.com",
                PhoneNumber = "1234567890",
                NormalizedEmail = "adminUser@EXAMPLE.COM",
                EmailConfirmed = true,
                LockoutEnabled = false
            };
            Admin.PasswordHash = hasher.HashPassword(Admin, "Admin@1+");
            var HotelManager = new ApplicationUser
            {
                Id = "2",
                UserName = "hotel",
                NormalizedUserName = "HOTEL",
                Email = "hotel@example.com",
                PhoneNumber = "1234567890",
                NormalizedEmail = "hotel@EXAMPLE.COM",
                EmailConfirmed = true,
                LockoutEnabled = false
            };
            HotelManager.PasswordHash = hasher.HashPassword(HotelManager, "Hotel@1+");
            var TripManager = new ApplicationUser
            {
                Id = "3",
                UserName = "trip",
                NormalizedUserName = "TRIP",
                Email = "trip@example.com",
                PhoneNumber = "1234567890",
                NormalizedEmail = "trip@EXAMPLE.COM",
                EmailConfirmed = true,
                LockoutEnabled = false
            };
            TripManager.PasswordHash = hasher.HashPassword(TripManager, "Trip@1+");

            var User = new ApplicationUser
            {
                Id = "4",
                UserName = "User",
                NormalizedUserName = "USER",
                Email = "User@example.com",
                PhoneNumber = "1234567890",
                EmailConfirmed = true,
                LockoutEnabled = false
            };
            User.PasswordHash = hasher.HashPassword(User, "User@1+");
            modelBuilder.Entity<ApplicationUser>().HasData(User);
            modelBuilder.Entity<ApplicationUser>().HasData(Admin);
            modelBuilder.Entity<ApplicationUser>().HasData(TripManager);
            modelBuilder.Entity<ApplicationUser>().HasData(HotelManager);

            // Seed User Roles
            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>()
    {
            new IdentityUserRole<string> { UserId ="1" , RoleId = "admin manager" },
            new IdentityUserRole<string> { UserId = "2", RoleId = "hotel manager" } ,
            new IdentityUserRole<string> { UserId = "3", RoleId = "trip manager" } ,
            new IdentityUserRole<string> { UserId = "4", RoleId = "user" }

    };
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);

            seedRole(modelBuilder, "Admin Manager", "create", "update", "delete", "read");
            seedRole(modelBuilder, "Trip Manager", "create", "update", "delete", "read");
            seedRole(modelBuilder, "Hotel Manager", "create", "update", "delete", "read");
            seedRole(modelBuilder, "User", "create", "update", "delete", "read");
        }
        int nextId = 1;
        private void seedRole(ModelBuilder modelBuilder, string roleName, params string[] permissions)
        {
            var role = new IdentityRole
            {
                Id = roleName.ToLower(),
                Name = roleName,
                NormalizedName = roleName.ToUpper(),
                ConcurrencyStamp = Guid.Empty.ToString()
            };
            var roleClaim = permissions.Select(permissions =>
            new IdentityRoleClaim<string>
            {
                Id = nextId++,
                RoleId = role.Id,
                ClaimType = "permissions",
                ClaimValue = permissions
            }).ToArray();
            modelBuilder.Entity<IdentityRole>().HasData(role);

        }

        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<TourSpot> TourSpots { get; set; }

        public DbSet<Trip> Trips { get; set; }

        public DbSet<HotelRoom> HotelRooms { get; set; }

        public DbSet<Rate> Rates { get; set; }

        public DbSet<BookingRoom> BookingRooms { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<RoomAmenity> RoomAmenities { get; set; }

        public DbSet<Facility> Facilities { get; set; }
        public DbSet<HotelFacility> HotelFacilities { get; set; }
        public DbSet<BookingTrip> bookingTrips { get; set; }

        public DbSet<Image> Images { get; set; }
    }
}
