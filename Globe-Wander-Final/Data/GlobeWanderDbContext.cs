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
               new TourSpot() { ID = 1, Name = "Petra", Country = "Jordan", City = "Petra", Description = "a place before thousands years", Category = Category.Historical, PhoneNumber = "078885423", Img= "https://images.pexels.com/photos/1631665/pexels-photo-1631665.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
               new TourSpot() { ID = 2, Name = "Jerash", Country = "Jordan", City = "Jerash", Description = "A historical place that the Romanian civilization build before thousands years.", Category = Category.Historical, PhoneNumber = "088782215",Img = "https://c0.wallpaperflare.com/preview/705/707/822/jordan-jerash-oval-plaza-market.jpg" },
               new TourSpot() { ID = 3, Name = "Um Qais", Country = "Jordan", City = "Irbid", Description = "A historical place that the Romanian civilization build before thousands years. In the north of Jordan", Category = Category.Historical, PhoneNumber = "0788442521",Img = "https://followinghadrianphotographycom.files.wordpress.com/2020/09/34509636386_2139ee3bc1_k.jpg?w=1075&h=712" },
               new TourSpot() { ID = 4, Name = "Wadi Rum", Country = "Jordan", City = "Aqaba", Description = "A spectacular desert in southern Jordan.", Category = Category.Natural, PhoneNumber = "0788555444",Img= "https://c4.wallpaperflare.com/wallpaper/774/140/860/nature-landscape-sand-desert-dunes-hd-wallpaper-preview.jpg" },
               new TourSpot() { ID = 5, Name = "Ajloun Castle", Country = "Jordan", City = "Ajloun", Description = "A 12th-century Muslim castle in northern Jordan.", Category = Category.Historical, PhoneNumber = "0799111122",Img= "https://as1.ftcdn.net/v2/jpg/02/49/78/08/1000_F_249780853_qBrIwoai4WNGR0OSx4I6A3EZZ47cUN5B.jpg" },
               new TourSpot() { ID = 6, Name = "Dead Sea", Country = "Jordan", City = "Amman", Description = "The lowest point on Earth and famous for its high salt content.", Category = Category.Natural, PhoneNumber = "0777888999",Img = "https://c4.wallpaperflare.com/wallpaper/884/827/830/dead-sea-coast-white-salt-blue-sea-wallpaper-preview.jpg" },
               new TourSpot() { ID = 7, Name = "Aqaba Beach", Country = "Jordan", City = "Aqaba", Description = "Beautiful beaches along the Red Sea.", Category = Category.Natural, PhoneNumber = "0799777666",Img = "https://wallpapers.com/images/high/aqaba-jordan-shoreline-y69cto406g6r0i5c.webp" },
               new TourSpot() { ID = 8, Name = "Wadi Al-Mujib", Country = "Jordan", City = "Madaba", Description = "Ancient hilltop fortress where John the Baptist was imprisoned.", Category = Category.Historical, PhoneNumber = "0777666555" , Img = "https://storage.kempinski.com/cdn-cgi/image/w=960,f=auto,g=auto,fit=scale-down/ki-cms-prod/images/4/5/5/3/313554-1-eng-GB/9e96e4717f7a-74342124_4K.jpg" },
               new TourSpot() { ID = 9, Name = "Dana Biosphere Reserve", Country = "Jordan", City = "Tafilah", Description = "A diverse ecological system in southern Jordan.", Category = Category.Natural, PhoneNumber = "0799888777", Img = "https://www.jordanbesttours.com/images/dana/jordan_nature_reserves_dana_full.jpg" }
               );
            modelBuilder.Entity<Trip>().HasData(

                new Trip() { Id = 1, TourSpotID = 1, Name = "Petra ride", Cost = 20, Capacity = 30, Count = 0, Activity = "walking", StartDate = DateTime.Now, EndDate = DateTime.UtcNow, Description = "trip start at 8 am and going from Amman to Petra" },
                new Trip() { Id = 2, TourSpotID = 2, Name = "Jerash ride", Cost = 30, Capacity = 22, Count = 0, Activity = "visiting", StartDate = DateTime.Now, EndDate = DateTime.UtcNow, Description = "Amman to Jerash with a trip manager who can speak many languages" },
                new Trip() { Id = 3, TourSpotID = 3, Name = "Um-Qais ride", Cost = 40, Capacity = 40, Count = 0, Activity = "climbing", StartDate = DateTime.Now, EndDate = DateTime.UtcNow, Description = "Amman to Irbid with a trip manager who can speak many languages" }
            );
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel() { Id = 1, TourSpotID = 1, Name = "Paradise", Description = "A unique hotel that you can't find in this place" },
                new Hotel() { Id = 2, TourSpotID = 2, Name = "Wander ", Description = "A unique hotel that you can't find in this place" },
                new Hotel() { Id = 3, TourSpotID = 3, Name = "Amazing", Description = "A unique hotel that y    ou can't find in this place" }
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
