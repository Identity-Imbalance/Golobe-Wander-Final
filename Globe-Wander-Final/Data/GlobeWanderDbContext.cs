﻿using Globe_Wander_Final.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
               new TourSpot() { ID = 1, Name = "Petra", Country = "Jordan", City = "Petra", Description = "a place before thousands years", Category = Category.Historical, PhoneNumber = "078885423" },
               new TourSpot() { ID = 2, Name = "Jerash", Country = "Jordan", City = "Jerash", Description = "A historical place that the Romanian civilization build before thousands years.", Category = Category.Historical, PhoneNumber = "088782215" },
               new TourSpot() { ID = 3, Name = "Um Qais", Country = "Jordan", City = "Irbid", Description = "A historical place that the Romanian civilization build before thousands years. In the north of Jordan", Category = Category.Historical, PhoneNumber = "0788442521" },
               new TourSpot() { ID = 4, Name = "Wadi Rum", Country = "Jordan", City = "Aqaba", Description = "A spectacular desert in southern Jordan.", Category = Category.Natural, PhoneNumber = "0788555444" },
               new TourSpot() { ID = 5, Name = "Ajloun Castle", Country = "Jordan", City = "Ajloun", Description = "A 12th-century Muslim castle in northern Jordan.", Category = Category.Historical, PhoneNumber = "0799111122" },
               new TourSpot() { ID = 6, Name = "Dead Sea", Country = "Jordan", City = "Amman", Description = "The lowest point on Earth and famous for its high salt content.", Category = Category.Natural, PhoneNumber = "0777888999" },
               new TourSpot() { ID = 7, Name = "Aqaba Beach", Country = "Jordan", City = "Aqaba", Description = "Beautiful beaches along the Red Sea.", Category = Category.Natural, PhoneNumber = "0799777666" },
               new TourSpot() { ID = 8, Name = "Machaerus", Country = "Jordan", City = "Madaba", Description = "Ancient hilltop fortress where John the Baptist was imprisoned.", Category = Category.Historical, PhoneNumber = "0777666555" },
               new TourSpot() { ID = 9, Name = "Dana Biosphere Reserve", Country = "Jordan", City = "Tafilah", Description = "A diverse ecological system in southern Jordan.", Category = Category.Natural, PhoneNumber = "0799888777" }
               );
            modelBuilder.Entity<Trip>().HasData(

                new Trip() { Id = 1, TourSpotID = 1, Name = "Petra ride", Cost = 20, Capacity = 30, Count = 0, Activity = "walking", StartDate = DateTime.Now, EndDate = DateTime.UtcNow, Description = "trip start at 8 am and going from Amman to Petra" },
                new Trip() { Id = 2, TourSpotID = 2, Name = "Jerash ride", Cost = 30, Capacity = 22, Count = 0, Activity = "visiting", StartDate = DateTime.Now, EndDate = DateTime.UtcNow, Description = "Amman to Jerash with a trip manager who can speak many languages" },
                new Trip() { Id = 3, TourSpotID = 3, Name = "Um-Qais ride", Cost = 40, Capacity = 40, Count = 0, Activity = "climbing", StartDate = DateTime.Now, EndDate = DateTime.UtcNow, Description = "Amman to Irbid with a trip manager who can speak many languages" }
            );
            modelBuilder.Entity<Hotel>().HasData(
            new Hotel() { Id = 1, TourSpotID = 1, Name = "Paradise", Description = "A unique hotel that you can't find in this place" },
            new Hotel() { Id = 2, TourSpotID = 2, Name = "Wander ", Description = "A unique hotel that you can't find in this place" },
            new Hotel() { Id = 3, TourSpotID = 3, Name = "Amazing", Description = "A unique hotel that you can't find in this place" },
            new Hotel() { Id = 4, TourSpotID = 2, Name = "Euphoria", Description = "Experience the best of hospitality with us" },
            new Hotel() { Id = 5, TourSpotID = 3, Name = "Serenity", Description = "Find your peace away from the hustle and bustle of the city" },
            new Hotel() { Id = 6, TourSpotID = 3, Name = "Harmony", Description = "A perfect blend of comfort and luxury" },

    new Hotel() { Id = 7, TourSpotID = 2, Name = "Oasis", Description = "A tranquil retreat in the heart of the city" },
    new Hotel() { Id = 8, TourSpotID = 2, Name = "Mirage", Description = "A luxury hotel that exceeds your expectations" },
    new Hotel() { Id = 9, TourSpotID = 3, Name = "Nirvana", Description = "Experience ultimate relaxation and comfort" },
    new Hotel() { Id = 10, TourSpotID = 1, Name = "Bliss", Description = "Your home away from home" },
    new Hotel() { Id = 11, TourSpotID = 1, Name = "Heaven", Description = "Experience the heavenly comfort and luxury" },
    new Hotel() { Id = 12, TourSpotID = 1, Name = "Eden", Description = "A paradise on earth for travelers" },
    new Hotel() { Id = 13, TourSpotID = 3, Name = "Utopia", Description = "A perfect place for a perfect vacation" },
    new Hotel() { Id = 14, TourSpotID = 2, Name = "Atlantis", Description = "Dive into the world of luxury and comfort" }
);

            modelBuilder.Entity<HotelRoom>().HasData(
    new HotelRoom() { RoomNumber = 101, HotelID = 1, RoomID = 1, PricePerDay = 100, IsAvailable = true },
    new HotelRoom() { RoomNumber = 102, HotelID = 1, RoomID = 2, PricePerDay = 120, IsAvailable = true },
    new HotelRoom() { RoomNumber = 201, HotelID = 2, RoomID = 3, PricePerDay = 150, IsAvailable = false },
    new HotelRoom() { RoomNumber = 202, HotelID = 2, RoomID = 1, PricePerDay = 180, IsAvailable = true },
    new HotelRoom() { RoomNumber = 301, HotelID = 3, RoomID = 3, PricePerDay = 200, IsAvailable = false },
    new HotelRoom() { RoomNumber = 302, HotelID = 3, RoomID = 2, PricePerDay = 220, IsAvailable = true },
    new HotelRoom() { RoomNumber = 401, HotelID = 4, RoomID = 3, PricePerDay = 250, IsAvailable = true },
    new HotelRoom() { RoomNumber = 402, HotelID = 4, RoomID = 2, PricePerDay = 280, IsAvailable = false },
    new HotelRoom() { RoomNumber = 501, HotelID = 5, RoomID = 1, PricePerDay = 300, IsAvailable = true },
    new HotelRoom() { RoomNumber = 502, HotelID = 5, RoomID = 1, PricePerDay = 320, IsAvailable = false },
    new HotelRoom() { RoomNumber = 601, HotelID = 6, RoomID = 2, PricePerDay = 350, IsAvailable = true },
    new HotelRoom() { RoomNumber = 602, HotelID = 6, RoomID = 2, PricePerDay = 380, IsAvailable = true },
    new HotelRoom() { RoomNumber = 701, HotelID = 7, RoomID = 3, PricePerDay = 400, IsAvailable = false },
    new HotelRoom() { RoomNumber = 702, HotelID = 7, RoomID = 2, PricePerDay = 430, IsAvailable = true },
    new HotelRoom() { RoomNumber = 801, HotelID = 8, RoomID = 1, PricePerDay = 450, IsAvailable = false },
    new HotelRoom() { RoomNumber = 802, HotelID = 8, RoomID = 1, PricePerDay = 480, IsAvailable = true },
    new HotelRoom() { RoomNumber = 901, HotelID = 9, RoomID = 3, PricePerDay = 500, IsAvailable = true },
    new HotelRoom() { RoomNumber = 902, HotelID = 9, RoomID = 2, PricePerDay = 530, IsAvailable = false },
    new HotelRoom() { RoomNumber = 1001, HotelID = 10, RoomID = 1, PricePerDay = 550, IsAvailable = true },
    new HotelRoom() { RoomNumber = 1002, HotelID = 10, RoomID = 2, PricePerDay = 580, IsAvailable = false },
    new HotelRoom() { RoomNumber = 1101, HotelID = 11, RoomID = 1, PricePerDay = 600, IsAvailable = true },
    new HotelRoom() { RoomNumber = 1102, HotelID = 11, RoomID = 3, PricePerDay = 630, IsAvailable = false },
    new HotelRoom() { RoomNumber = 1201, HotelID = 12, RoomID = 2, PricePerDay = 650, IsAvailable = true },
    new HotelRoom() { RoomNumber = 1202, HotelID = 12, RoomID = 3, PricePerDay = 680, IsAvailable = true },
    
    new HotelRoom() { RoomNumber = 1301, HotelID = 13, RoomID = 2, PricePerDay = 700, IsAvailable = false },
    new HotelRoom() { RoomNumber = 1302, HotelID = 13, RoomID = 2, PricePerDay = 730, IsAvailable = true },
    new HotelRoom() { RoomNumber = 1401, HotelID = 14, RoomID = 3, PricePerDay = 750, IsAvailable = false },
    new HotelRoom() { RoomNumber = 1402, HotelID = 14, RoomID = 3, PricePerDay = 780, IsAvailable = true }
    
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

        public DbSet<BookingTrip> bookingTrips { get; set; }
    }
}
