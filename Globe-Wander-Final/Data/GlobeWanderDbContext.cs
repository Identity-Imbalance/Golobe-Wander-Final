﻿using Globe_Wander_Final.Models;
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
    new TourSpot() { ID = 1, Name = "Petra", Country = "Jordan", City = "Petra", Description = "Step back in time as you enter the ancient Nabatean city of Petra, a UNESCO World Heritage Site and one of the New Seven Wonders of the World. Marvel at the intricately carved facades, explore the hidden tombs, and soak in the sheer grandeur of this archaeological masterpiece.", Category = Category.Historical, PhoneNumber = "078885423", Img = "https://images.pexels.com/photos/1631665/pexels-photo-1631665.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
    new TourSpot() { ID = 2, Name = "Jerash", Country = "Jordan", City = "Jerash", Description = "Uncover the secrets of Jerash, one of the best-preserved Roman cities in the world. Wander through its well-preserved streets, temples, and theaters, and let the whispers of ancient civilizations echo through time.", Category = Category.Historical, PhoneNumber = "088782215", Img = "https://c0.wallpaperflare.com/preview/705/707/822/jordan-jerash-oval-plaza-market.jpg" },
    new TourSpot() { ID = 3, Name = "Um Qais", Country = "Jordan", City = "Irbid", Description = "Perched on a hill overlooking the Sea of Galilee, Um Qais offers panoramic views of the Jordan Valley, Golan Heights, and the Sea of Tiberias. This ancient Decapolis city invites you to wander among its Roman ruins and absorb the stunning natural beauty of the region.", Category = Category.Historical, PhoneNumber = "0788442521", Img = "https://followinghadrianphotographycom.files.wordpress.com/2020/09/34509636386_2139ee3bc1_k.jpg?w=1075&h=712" },
    new TourSpot() { ID = 4, Name = "Wadi Rum", Country = "Jordan", City = "Aqaba", Description = "Prepare to be enchanted by the surreal landscapes of Wadi Rum, often referred to as the \"Valley of the Moon.\" Traverse its vast desert expanse, characterized by towering sandstone mountains and shifting sands. Experience the magic of Bedouin culture through traditional meals and starlit desert camping.", Category = Category.Natural, PhoneNumber = "0788555444", Img = "https://c4.wallpaperflare.com/wallpaper/774/140/860/nature-landscape-sand-desert-dunes-hd-wallpaper-preview.jpg" },
    new TourSpot() { ID = 5, Name = "Ajloun Castle", Country = "Jordan", City = "Ajloun", Description = "Ajloun Castle stands proudly amidst the lush green hills of northern Jordan. This 12th-century fortress offers a glimpse into the region's medieval history and provides breathtaking views of the surrounding countryside.", Category = Category.Historical, PhoneNumber = "0799111122", Img = "https://as1.ftcdn.net/v2/jpg/02/49/78/08/1000_F_249780853_qBrIwoai4WNGR0OSx4I6A3EZZ47cUN5B.jpg" },
    new TourSpot() { ID = 6, Name = "Dead Sea", Country = "Jordan", City = "Amman", Description = "Indulge in the therapeutic wonders of the Dead Sea, the lowest point on Earth. Float effortlessly on its mineral-rich waters and rejuvenate your skin with its famed mud. The surreal landscape and unique experiences make this natural wonder a must-visit.", Category = Category.Natural, PhoneNumber = "0777888999", Img = "https://c4.wallpaperflare.com/wallpaper/884/827/830/dead-sea-coast-white-salt-blue-sea-wallpaper-preview.jpg" },
    new TourSpot() { ID = 7, Name = "Aqaba Beach", Country = "Jordan", City = "Aqaba", Description = "Beautiful beaches along the Red Sea.", Category = Category.Natural, PhoneNumber = "0799777666", Img = "https://wallpapers.com/images/high/aqaba-jordan-shoreline-y69cto406g6r0i5c.webp" },
    new TourSpot() { ID = 8, Name = "Wadi Al-Mujib", Country = "Jordan", City = "Madaba", Description = "Ancient hilltop fortress where John the Baptist was imprisoned.", Category = Category.Historical, PhoneNumber = "0777666555", Img = "https://storage.kempinski.com/cdn-cgi/image/w=960,f=auto,g=auto,fit=scale-down/ki-cms-prod/images/4/5/5/3/313554-1-eng-GB/9e96e4717f7a-74342124_4K.jpg" },
    new TourSpot() { ID = 9, Name = "Dana Biosphere Reserve", Country = "Jordan", City = "Tafilah", Description = "A diverse ecological system in southern Jordan.", Category = Category.Natural, PhoneNumber = "0799888777", Img = "https://www.jordanbesttours.com/images/dana/jordan_nature_reserves_dana_full.jpg" }
    );
            modelBuilder.Entity<Trip>().HasData(

    new Trip() { Id = 1, TourSpotID = 1, Name = "Petra ride", Cost = 20, Capacity = 30, Count = 0, Activity = "walking", StartDate = DateTime.Parse("2023-10-27"), EndDate = DateTime.Parse("2023-10-30"), Description = "trip starts at 8 am and goes from Amman to Petra" },
    new Trip() { Id = 2, TourSpotID = 1, Name = "Jerash ride", Cost = 30, Capacity = 22, Count = 0, Activity = "visiting", StartDate = DateTime.Parse("2023-10-31"), EndDate = DateTime.Parse("2023-11-3"), Description = "Amman to Jerash with a trip manager who can speak many languages" },
    new Trip() { Id = 3, TourSpotID = 1, Name = "Um-Qais ride", Cost = 40, Capacity = 40, Count = 0, Activity = "climbing", StartDate = DateTime.Parse("2023-11-4"), EndDate = DateTime.Parse("2023-11-7"), Description = "Amman to Irbid with a trip manager who can speak many languages" },

    new Trip() { Id = 4, TourSpotID = 2, Name = "Wadi Rum Adventure", Cost = 50, Capacity = 20, Count = 0, Activity = "desert safari", StartDate = DateTime.Parse("2023-11-10"), EndDate = DateTime.Parse("2023-11-13"), Description = "Explore the breathtaking Wadi Rum desert in Jordan." },
    new Trip() { Id = 5, TourSpotID = 2, Name = "Dead Sea Relaxation", Cost = 25, Capacity = 15, Count = 0, Activity = "swimming and mud baths", StartDate = DateTime.Parse("2023-11-14"), EndDate = DateTime.Parse("2023-11-17"), Description = "Relax at the world-famous Dead Sea and experience its healing properties." },
    new Trip() { Id = 6, TourSpotID = 2, Name = "Aqaba Diving Expedition", Cost = 60, Capacity = 10, Count = 0, Activity = "scuba diving", StartDate = DateTime.Parse("2023-11-20"), EndDate = DateTime.Parse("2023-11-23"), Description = "Discover the vibrant marine life of the Red Sea in Aqaba." },

    new Trip() { Id = 7, TourSpotID = 3, Name = "Amman City Tour", Cost = 15, Capacity = 25, Count = 0, Activity = "sightseeing", StartDate = DateTime.Parse("2023-11-25"), EndDate = DateTime.Parse("2023-11-28"), Description = "Explore the historical and cultural landmarks of Amman." },
    new Trip() { Id = 8, TourSpotID = 3, Name = "Dana Biosphere Reserve Hike", Cost = 35, Capacity = 12, Count = 0, Activity = "hiking", StartDate = DateTime.Parse("2023-12-1"), EndDate = DateTime.Parse("2023-12-4"), Description = "Trek through the stunning Dana Biosphere Reserve." },
    new Trip() { Id = 9, TourSpotID = 3, Name = "Wadi Mujib Canyoning", Cost = 45, Capacity = 18, Count = 0, Activity = "canyoning", StartDate = DateTime.Parse("2023-12-7"), EndDate = DateTime.Parse("2023-12-10"), Description = "Experience the adventure of canyoning in Wadi Mujib." },

    new Trip() { Id = 10, TourSpotID = 4, Name = "Ma'in Hot Springs Visit", Cost = 20, Capacity = 30, Count = 0, Activity = "relaxation", StartDate = DateTime.Parse("2023-12-13"), EndDate = DateTime.Parse("2023-12-16"), Description = "Relax in the soothing hot springs of Ma'in." },
    new Trip() { Id = 11, TourSpotID = 4, Name = "Kerak Castle Tour", Cost = 25, Capacity = 20, Count = 0, Activity = "historical tour", StartDate = DateTime.Parse("2023-12-19"), EndDate = DateTime.Parse("2023-12-22"), Description = "Explore the historic Kerak Castle in Jordan." },
    new Trip() { Id = 12, TourSpotID = 4, Name = "Ajloun Forest Reserve Trek", Cost = 30, Capacity = 15, Count = 0, Activity = "nature walk", StartDate = DateTime.Parse("2023-12-25"), EndDate = DateTime.Parse("2023-12-28"), Description = "Take a nature walk in the Ajloun Forest Reserve." },

    new Trip() { Id = 13, TourSpotID = 4, Name = "Amman Culinary Tour", Cost = 40, Capacity = 12, Count = 0, Activity = "food tasting", StartDate = DateTime.Parse("2023-12-31"), EndDate = DateTime.Parse("2024-1-3"), Description = "Indulge in a culinary journey through Amman's cuisine." },
    new Trip() { Id = 14, TourSpotID = 4, Name = "Mosaic City Madaba", Cost = 20, Capacity = 25, Count = 0, Activity = "mosaic art", StartDate = DateTime.Parse("2024-1-6"), EndDate = DateTime.Parse("2024-1-9"), Description = "Discover the mosaic art of Madaba." },
    new Trip() { Id = 15, TourSpotID = 4, Name = "Ajloun Castle Exploration", Cost = 30, Capacity = 18, Count = 0, Activity = "historical tour", StartDate = DateTime.Parse("2024-1-12"), EndDate = DateTime.Parse("2024-1-15"), Description = "Explore the historic Ajloun Castle." },

    new Trip() { Id = 16, TourSpotID = 5, Name = "Aqaba Beach Getaway", Cost = 55, Capacity = 20, Count = 0, Activity = "beach relaxation", StartDate = DateTime.Parse("2024-1-18"), EndDate = DateTime.Parse("2024-1-21"), Description = "Relax on the beautiful beaches of Aqaba." },
    new Trip() { Id = 17, TourSpotID = 5, Name = "Aqaba Snorkeling Adventure", Cost = 40, Capacity = 15, Count = 0, Activity = "snorkeling", StartDate = DateTime.Parse("2024-1-22"), EndDate = DateTime.Parse("2024-1-27"), Description = "Explore the underwater world of the Red Sea through snorkeling in Aqaba." },
                    new Trip() { Id = 18, TourSpotID = 5, Name = "Aqaba Glass-Bottom Boat Tour", Cost = 30, Capacity = 25, Count = 0, Activity = "boat tour", StartDate = DateTime.Parse("2024-1-28"), EndDate = DateTime.Parse("2024-1-31"), Description = "View marine life through a glass-bottom boat tour in Aqaba." },
new Trip() { Id = 19, TourSpotID = 6, Name = "Aqaba Desert Jeep Safari", Cost = 45, Capacity = 12, Count = 0, Activity = "desert adventure", StartDate = DateTime.Parse("2024-2-3"), EndDate = DateTime.Parse("2024-2-6"), Description = "Embark on an exciting jeep safari in the Aqaba desert." },
new Trip() { Id = 20, TourSpotID = 6, Name = "Aqaba Nightlife Tour", Cost = 25, Capacity = 20, Count = 0, Activity = "nightclub hopping", StartDate = DateTime.Parse("2024-2-9"), EndDate = DateTime.Parse("2024-2-12"), Description = "Experience the vibrant nightlife of Aqaba." },
new Trip() { Id = 21, TourSpotID = 6, Name = "Pyramids of Giza Tour", Cost = 60, Capacity = 15, Count = 0, Activity = "historical tour", StartDate = DateTime.Parse("2024-2-15"), EndDate = DateTime.Parse("2024-2-18"), Description = "Explore the iconic Pyramids of Giza in Egypt." },
new Trip() { Id = 22, TourSpotID = 7, Name = "Broadway Show Experience", Cost = 60, Capacity = 18, Count = 0, Activity = "theater", StartDate = DateTime.Parse("2024-2-22"), EndDate = DateTime.Parse("2024-2-25"), Description = "Attend a Broadway show in the heart of New York City." },
new Trip() { Id = 23, TourSpotID = 7, Name = "Museum Mile Tour", Cost = 30, Capacity = 20, Count = 0, Activity = "museum visit", StartDate = DateTime.Parse("2024-2-28"), EndDate = DateTime.Parse("2024-3-2"), Description = "Explore the museums along Museum Mile." },
new Trip() { Id = 24, TourSpotID = 7, Name = "Brooklyn Bridge Walk", Cost = 20, Capacity = 35, Count = 0, Activity = "walking tour", StartDate = DateTime.Parse("2024-3-6"), EndDate = DateTime.Parse("2024-3-9"), Description = "Take a scenic walk across the historic Brooklyn Bridge." },
new Trip() { Id = 25, TourSpotID = 8, Name = "Empire State Building Observation Deck", Cost = 35, Capacity = 30, Count = 0, Activity = "sightseeing", StartDate = DateTime.Parse("2024-3-12"), EndDate = DateTime.Parse("2024-3-15"), Description = "Enjoy panoramic views from the Empire State Building." },
new Trip() { Id = 26, TourSpotID = 8, Name = "Hudson River Boat Tour", Cost = 45, Capacity = 25, Count = 0, Activity = "boat tour", StartDate = DateTime.Parse("2024-3-18"), EndDate = DateTime.Parse("2024-3-21"), Description = "Cruise along the Hudson River and see Manhattan's skyline." },
new Trip() { Id = 27, TourSpotID = 8, Name = "Ubud Cultural Experience", Cost = 45, Capacity = 20, Count = 0, Activity = "cultural tour", StartDate = DateTime.Parse("2024-3-24"), EndDate = DateTime.Parse("2024-3-27"), Description = "Immerse in the rich culture of Ubud, Bali." },
new Trip() { Id = 28, TourSpotID = 9, Name = "Red Sea Adventure", Cost = 60, Capacity = 30, Count = 0, Activity = "snorkeling", StartDate = DateTime.Parse("2024-3-31"), EndDate = DateTime.Parse("2024-4-3"), Description = "Explore the vibrant marine life of the Red Sea in Aqaba" },
new Trip() { Id = 29, TourSpotID = 9, Name = "Desert Safari", Cost = 50, Capacity = 20, Count = 0, Activity = "off-roading", StartDate = DateTime.Parse("2024-4-6"), EndDate = DateTime.Parse("2024-4-9"), Description = "Experience the thrill of a desert adventure in Aqaba" },
new Trip() { Id = 30, TourSpotID = 9, Name = "Historical Dive", Cost = 70, Capacity = 15, Count = 0, Activity = "scuba diving", StartDate = DateTime.Parse("2024-4-12"), EndDate = DateTime.Parse("2024-4-15"), Description = "Discover submerged historical sites in the Red Sea" }
);





            modelBuilder.Entity<Hotel>().HasData(
       new Hotel() { Id = 1, TourSpotID = 1, Name = "Harmony", Location = "amman", StarRate = 4, Description = "A peaceful retreat in the heart of the city" },
        new Hotel() { Id = 2, TourSpotID = 2, Name = "Adventure", Location = "wadi rum", StarRate = 3, Description = "The perfect base for your desert adventure" },
        new Hotel() { Id = 3, TourSpotID = 3, Name = "Oasis", Location = "dead sea", StarRate = 5, Description = "A luxury resort on the shores of the Dead Sea" },
        new Hotel() { Id = 4, TourSpotID = 1, Name = "Heritage", Location = "jerash", StarRate = 4, Description = "Experience the rich history of Jerash" },
        new Hotel() { Id = 5, TourSpotID = 2, Name = "Horizon", Location = "aqaba", StarRate = 5, Description = "Stunning sea views in a modern setting" }
    );
            modelBuilder.Entity<HotelRoom>().HasData(
       new HotelRoom { RoomNumber = 101, HotelID = 1, RoomID = 1, Description = " A spacious room with a king-size bed, modern amenities, and a beautiful city view.", SquareFeet = 500, Bathrooms = 1, Beds = 2, PricePerDay = 150.00m, IsAvailable = true },
    new HotelRoom { RoomNumber = 102, HotelID = 1, RoomID = 2, Description = " A luxurious suite with two queen-size beds, a mini bar, a private balcony with ocean views, and premium toiletries.", SquareFeet = 700, Bathrooms = 2, Beds = 2, PricePerDay = 200.00m, IsAvailable = true },
    new HotelRoom { RoomNumber = 103, HotelID = 1, RoomID = 3, Description = "A large studio with a separate living area, king-size bed, two bathrooms, and a private terrace overlooking the city.", SquareFeet = 1000, Bathrooms = 2, Beds = 1, PricePerDay = 300.00m, IsAvailable = true },

     new HotelRoom { RoomNumber = 201, HotelID = 2, RoomID = 1, Description = " A spacious room with a king-size bed, modern amenities, and a beautiful city view.", SquareFeet = 500, Bathrooms = 1, Beds = 2, PricePerDay = 150.00m, IsAvailable = true },
    new HotelRoom { RoomNumber = 202, HotelID = 2, RoomID = 2, Description = " A luxurious suite with two queen-size beds, a mini bar, a private balcony with ocean views, and premium toiletries.", SquareFeet = 700, Bathrooms = 2, Beds = 2, PricePerDay = 200.00m, IsAvailable = true },
    new HotelRoom { RoomNumber = 203, HotelID = 2, RoomID = 3, Description = "A large studio with a separate living area, king-size bed, two bathrooms, and a private terrace overlooking the city.", SquareFeet = 1000, Bathrooms = 2, Beds = 1, PricePerDay = 300.00m, IsAvailable = true },

     new HotelRoom { RoomNumber = 301, HotelID = 3, RoomID = 1, Description = " A spacious room with a king-size bed, modern amenities, and a beautiful city view.", SquareFeet = 500, Bathrooms = 1, Beds = 2, PricePerDay = 150.00m, IsAvailable = true },
    new HotelRoom { RoomNumber = 302, HotelID = 3, RoomID = 2, Description = " A luxurious suite with two queen-size beds, a mini bar, a private balcony with ocean views, and premium toiletries.", SquareFeet = 700, Bathrooms = 2, Beds = 2, PricePerDay = 200.00m, IsAvailable = true },
    new HotelRoom { RoomNumber = 303, HotelID = 3, RoomID = 3, Description = "A large studio with a separate living area, king-size bed, two bathrooms, and a private terrace overlooking the city.", SquareFeet = 1000, Bathrooms = 2, Beds = 1, PricePerDay = 300.00m, IsAvailable = true },

     new HotelRoom { RoomNumber = 401, HotelID = 4, RoomID = 1, Description = " A spacious room with a king-size bed, modern amenities, and a beautiful city view.", SquareFeet = 500, Bathrooms = 1, Beds = 2, PricePerDay = 150.00m, IsAvailable = true },
    new HotelRoom { RoomNumber = 402, HotelID = 4, RoomID = 2, Description = " A luxurious suite with two queen-size beds, a mini bar, a private balcony with ocean views, and premium toiletries.", SquareFeet = 700, Bathrooms = 2, Beds = 2, PricePerDay = 200.00m, IsAvailable = true },
    new HotelRoom { RoomNumber = 403, HotelID = 4, RoomID = 3, Description = "A large studio with a separate living area, king-size bed, two bathrooms, and a private terrace overlooking the city.", SquareFeet = 1000, Bathrooms = 2, Beds = 1, PricePerDay = 300.00m, IsAvailable = true },

     new HotelRoom { RoomNumber = 501, HotelID = 5, RoomID = 1, Description = " A spacious room with a king-size bed, modern amenities, and a beautiful city view.", SquareFeet = 500, Bathrooms = 1, Beds = 2, PricePerDay = 150.00m, IsAvailable = true },
    new HotelRoom { RoomNumber = 502, HotelID = 5, RoomID = 2, Description = " A luxurious suite with two queen-size beds, a mini bar, a private balcony with ocean views, and premium toiletries.", SquareFeet = 700, Bathrooms = 2, Beds = 2, PricePerDay = 200.00m, IsAvailable = true },
    new HotelRoom { RoomNumber = 503, HotelID = 5, RoomID = 3, Description = "A large studio with a separate living area, king-size bed, two bathrooms, and a private terrace overlooking the city.", SquareFeet = 1000, Bathrooms = 2, Beds = 1, PricePerDay = 300.00m, IsAvailable = true }


);
            modelBuilder.Entity<Image>().HasData(
            new Image { Id = 1, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", HotelId = 1 },
              new Image { Id = 2, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", HotelId = 1 },
                  new Image { Id = 3, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", HotelId = 1 },
                      new Image { Id = 4, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", HotelId = 1 },
                          new Image { Id = 5, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", HotelId = 1 },
                           new Image { Id = 6, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", HotelId = 1 },
                      new Image { Id = 7, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", HotelId = 1 },


              new Image { Id = 8, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel2image2.jpg", HotelId = 2 },
                      new Image { Id = 9, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel2image1.jpg", HotelId = 2 },
                  new Image { Id = 10, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel2image3.jpg", HotelId = 2 },
                      new Image { Id = 11, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel2image4.jpg", HotelId = 2 },
                          new Image { Id = 12, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel2image5.jpg", HotelId = 2 },
                            new Image { Id = 13, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel2image3.jpg", HotelId = 2 },
                      new Image { Id = 14, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel2image4.jpg", HotelId = 2 },

         new Image { Id = 15, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", HotelId = 3 },
              new Image { Id = 16, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", HotelId = 3 },
                  new Image { Id = 17, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", HotelId = 3 },
                        new Image { Id = 18, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", HotelId = 3 },
                           new Image { Id = 19, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", HotelId = 3 },
new Image { Id = 20, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", HotelId = 3 },
                        new Image { Id = 21, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", HotelId = 3 },

                              new Image { Id = 22, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", HotelId = 4 },
         new Image { Id = 23, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", HotelId = 4 },
                  new Image { Id = 24, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", HotelId = 4 },
                      new Image { Id = 25, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", HotelId = 4 },
                          new Image { Id = 26, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", HotelId = 4 },
                           new Image { Id = 27, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", HotelId = 4 },
                      new Image { Id = 28, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", HotelId = 4 },


                   new Image { Id = 29, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", HotelId = 5 },
              new Image { Id = 30, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", HotelId = 5 },
              new Image { Id = 31, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", HotelId = 5 },
                      new Image { Id = 32, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", HotelId = 5 },
                          new Image { Id = 33, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", HotelId = 5 },
       new Image { Id = 34, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", HotelId = 5 },
              new Image { Id = 35, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", HotelId = 5 },


                      ///////////hotelroom1
                      new Image { Id = 36, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", HotelId = 1, RoomNumber = 101 },
              new Image { Id = 37, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", HotelId = 1, RoomNumber = 101 },
              new Image { Id = 38, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", HotelId = 1, RoomNumber = 101 },
               new Image { Id = 39, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", HotelId = 1, RoomNumber = 101 },
                          new Image { Id = 40, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", HotelId = 1, RoomNumber = 101 },
       new Image { Id = 41, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", HotelId = 1, RoomNumber = 101 },
              new Image { Id = 42, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", HotelId = 1, RoomNumber = 101 },


         new Image { Id = 43, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", HotelId = 1, RoomNumber = 102 },
              new Image { Id = 44, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", HotelId = 1, RoomNumber = 102 },
              new Image { Id = 45, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", HotelId = 1, RoomNumber = 102 },
                      new Image { Id = 46, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", HotelId = 1, RoomNumber = 102 },
                        new Image { Id = 47, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", HotelId = 1, RoomNumber = 102 },
       new Image { Id = 48, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", HotelId = 1, RoomNumber = 102 },
              new Image { Id = 49, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", HotelId = 1, RoomNumber = 102 },


                new Image { Id = 50, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", HotelId = 1, RoomNumber = 103 },
              new Image { Id = 51, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", HotelId = 1, RoomNumber = 103 },
              new Image { Id = 52, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", HotelId = 1, RoomNumber = 103 },
                      new Image { Id = 53, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", HotelId = 1, RoomNumber = 103 },
                          new Image { Id = 54, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", HotelId = 1, RoomNumber = 103 },
       new Image { Id = 55, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", HotelId = 1, RoomNumber = 103 },
              new Image { Id = 56, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", HotelId = 1, RoomNumber = 103 },

                                        ///////////hotelroom2
                                        new Image { Id = 57, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", HotelId = 2, RoomNumber = 201 },
              new Image { Id = 58, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", HotelId = 2, RoomNumber = 201 },
              new Image { Id = 59, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", HotelId = 2, RoomNumber = 201 },
                      new Image { Id = 60, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", HotelId = 2, RoomNumber = 201 },
                        new Image { Id = 61, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", HotelId = 2, RoomNumber = 201 },
       new Image { Id = 62, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", HotelId = 2, RoomNumber = 201 },
              new Image { Id = 63, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", HotelId = 2, RoomNumber = 201 },


                      new Image { Id = 64, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", HotelId = 2, RoomNumber = 202 },
                new Image { Id = 65, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", HotelId = 2, RoomNumber = 202 },
              new Image { Id = 66, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", HotelId = 2, RoomNumber = 202 },
                      new Image { Id = 67, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", HotelId = 2, RoomNumber = 202 },
                          new Image { Id = 68, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", HotelId = 2, RoomNumber = 202 },
       new Image { Id = 69, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", HotelId = 2, RoomNumber = 202 },
              new Image { Id = 70, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", HotelId = 2, RoomNumber = 202 },


 new Image { Id = 71, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", HotelId = 2, RoomNumber = 203 },
              new Image { Id = 72, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", HotelId = 2, RoomNumber = 203 },
                              new Image { Id = 73, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", HotelId = 2, RoomNumber = 203 },
              new Image { Id = 74, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", HotelId = 2, RoomNumber = 203 },
                          new Image { Id = 75, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", HotelId = 2, RoomNumber = 203 },
       new Image { Id = 76, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", HotelId = 2, RoomNumber = 203 },
              new Image { Id = 77, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", HotelId = 2, RoomNumber = 203 },

                 ///////////hotelroom3

                 new Image { Id = 78, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", HotelId = 3, RoomNumber = 301 },
              new Image { Id = 79, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", HotelId = 3, RoomNumber = 301 },
              new Image { Id = 80, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", HotelId = 3, RoomNumber = 301 },
                            new Image { Id = 81, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", HotelId = 3, RoomNumber = 301 },
                          new Image { Id = 82, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", HotelId = 3, RoomNumber = 301 },
       new Image { Id = 83, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", HotelId = 3, RoomNumber = 301 },
              new Image { Id = 84, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", HotelId = 3, RoomNumber = 301 },


              new Image { Id = 85, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", HotelId = 3, RoomNumber = 302 },
              new Image { Id = 86, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", HotelId = 3, RoomNumber = 302 },
              new Image { Id = 87, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", HotelId = 3, RoomNumber = 302 },
                      new Image { Id = 88, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", HotelId = 3, RoomNumber = 302 },
                          new Image { Id = 89, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", HotelId = 3, RoomNumber = 302 },
       new Image { Id = 90, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", HotelId = 3, RoomNumber = 302 },
              new Image { Id = 91, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", HotelId = 3, RoomNumber = 302 },


               new Image { Id = 92, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", HotelId = 3, RoomNumber = 303 },
              new Image { Id = 93, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", HotelId = 3, RoomNumber = 303 },
              new Image { Id = 94, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", HotelId = 3, RoomNumber = 303 },
                      new Image { Id = 95, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", HotelId = 3, RoomNumber = 303 },
                          new Image { Id = 96, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", HotelId = 3, RoomNumber = 303 },
          new Image { Id = 97, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", HotelId = 3, RoomNumber = 303 },
                          new Image { Id = 98, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", HotelId = 3, RoomNumber = 303 },

                ///////////hotelroom4

                new Image { Id = 99, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", HotelId = 4, RoomNumber = 401 },

              new Image { Id = 100, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", HotelId = 4, RoomNumber = 401 },
              new Image { Id = 101, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", HotelId = 4, RoomNumber = 401 },
                      new Image { Id = 102, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", HotelId = 4, RoomNumber = 401 },
                          new Image { Id = 103, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", HotelId = 4, RoomNumber = 401 },
       new Image { Id = 104, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", HotelId = 4, RoomNumber = 401 },
             new Image { Id = 105, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", HotelId = 4, RoomNumber = 401 },



  new Image { Id = 106, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", HotelId = 4, RoomNumber = 402 },
              new Image { Id = 107, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", HotelId = 4, RoomNumber = 402 },
                  new Image { Id = 108, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", HotelId = 4, RoomNumber = 402 },
                      new Image { Id = 109, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", HotelId = 4, RoomNumber = 402 },
                          new Image { Id = 110, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", HotelId = 4, RoomNumber = 402 },
       new Image { Id = 111, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", HotelId = 4, RoomNumber = 402 },
              new Image { Id = 112, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", HotelId = 4, RoomNumber = 402 },


               new Image { Id = 113, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", HotelId = 4, RoomNumber = 403 },
              new Image { Id = 114, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", HotelId = 4, RoomNumber = 403 },
              new Image { Id = 115, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", HotelId = 4, RoomNumber = 403 },
                        new Image { Id = 116, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", HotelId = 4, RoomNumber = 403 },
                          new Image { Id = 117, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", HotelId = 4, RoomNumber = 403 },
       new Image { Id = 118, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", HotelId = 4, RoomNumber = 403 },
              new Image { Id = 119, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", HotelId = 4, RoomNumber = 403 },

                 ///////////hotelroom5

                 new Image { Id = 120, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", HotelId = 5, RoomNumber = 501 },
              new Image { Id = 121, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", HotelId = 5, RoomNumber = 501 },
              new Image { Id = 122, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", HotelId = 5, RoomNumber = 501 },
                      new Image { Id = 123, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", HotelId = 5, RoomNumber = 501 },
                       new Image { Id = 124, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", HotelId = 5, RoomNumber = 501 },
       new Image { Id = 125, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", HotelId = 5, RoomNumber = 501 },
              new Image { Id = 126, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", HotelId = 5, RoomNumber = 501 },



     new Image { Id = 127, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", HotelId = 5, RoomNumber = 502 },
                new Image { Id = 128, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", HotelId = 5, RoomNumber = 502 },
              new Image { Id = 129, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", HotelId = 5, RoomNumber = 502 },
              new Image { Id = 130, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", HotelId = 5, RoomNumber = 502 },
                      new Image { Id = 131, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", HotelId = 5, RoomNumber = 502 },
                      new Image { Id = 132, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", HotelId = 5, RoomNumber = 502 },
       new Image { Id = 133, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", HotelId = 5, RoomNumber = 502 },



                            new Image { Id = 134, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", HotelId = 5, RoomNumber = 503 },
                new Image { Id = 135, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", HotelId = 5, RoomNumber = 503 },
              new Image { Id = 136, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", HotelId = 5, RoomNumber = 503 },
              new Image { Id = 137, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", HotelId = 5, RoomNumber = 503 },
                      new Image { Id = 138, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", HotelId = 5, RoomNumber = 503 },
                          new Image { Id = 139, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", HotelId = 5, RoomNumber = 503 },
       new Image { Id = 140, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", HotelId = 5, RoomNumber = 503 },

        // Trip Images
        new Image { Id = 141, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip1.jpg", TripId = 1 },
        new Image { Id = 142, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip2.jpg", TripId = 2 },
        new Image { Id = 143, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip3.jpg", TripId = 3 },
        new Image { Id = 144, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip4.jpg", TripId = 4 },
        new Image { Id = 145, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip5.jpeg", TripId = 5 },
        new Image { Id = 146, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip6.jpg", TripId = 6 },
        new Image { Id = 147, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip7.png", TripId = 7 },
        new Image { Id = 148, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip8.jpg", TripId = 8 },
        new Image { Id = 149, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip9.jpg", TripId = 9 },
        new Image { Id = 150, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip10.jpg", TripId = 10 },
        new Image { Id = 151, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip3.jpg", TripId = 11 },
        new Image { Id = 152, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip1.jpg", TripId = 12 },
        new Image { Id = 153, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip2.jpg", TripId = 13 },
        new Image { Id = 154, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip9.jpg", TripId = 14 },
        new Image { Id = 155, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip9.jpg", TripId = 15 },
        new Image { Id = 156, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip1.jpg", TripId = 16 },
        new Image { Id = 157, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip10.jpg", TripId = 17 },
        new Image { Id = 158, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip5.jpg", TripId = 18 },
        new Image { Id = 159, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip1.jpg", TripId = 19 },
        new Image { Id = 160, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip9.jpg", TripId = 20 },
        new Image { Id = 161, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip10.jpg", TripId = 21 },
        new Image { Id = 162, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip9.jpg", TripId = 22 },
        new Image { Id = 163, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip1.jpg", TripId = 23 },
        new Image { Id = 164, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip10.jpg", TripId = 24 },
        new Image { Id = 165, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip7.png", TripId = 25 },
        new Image { Id = 166, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip10.jpg", TripId = 26 },
        new Image { Id = 167, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip1.jpg", TripId = 27 },
        new Image { Id = 168, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip7.png", TripId = 28 },
        new Image { Id = 169, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip10.jpg", TripId = 29 },
        new Image { Id = 170, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip1.jpg", TripId = 30 }



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
    new RoomAmenity() { Id = 4, RoomId = 3, AmenityId = 1 },
     new RoomAmenity() { Id = 5, RoomId = 3, AmenityId = 2 },
      new RoomAmenity() { Id = 6, RoomId = 3, AmenityId = 3 }
);


            modelBuilder.Entity<Facility>().HasData(
                    new Facility() { Id = 1, Name = "Swming pool" },
                    new Facility() { Id = 2, Name = "resturants" },
                    new Facility() { Id = 3, Name = "GYM" }
                );
            modelBuilder.Entity<HotelFacility>().HasData(
    new HotelFacility() { Id = 1, FacilityId = 1, HotelId = 1 },
    new HotelFacility() { Id = 2, FacilityId = 1, HotelId = 2 },
    new HotelFacility() { Id = 3, FacilityId = 2, HotelId = 3 },
    new HotelFacility() { Id = 4, FacilityId = 3, HotelId = 1 },
    new HotelFacility() { Id = 5, FacilityId = 1, HotelId = 2 },
    new HotelFacility() { Id = 6, FacilityId = 1, HotelId = 3 },
    new HotelFacility() { Id = 7, FacilityId = 2, HotelId = 4 },
    new HotelFacility() { Id = 8, FacilityId = 3, HotelId = 5 },
    new HotelFacility() { Id = 10, FacilityId = 1, HotelId = 4 },
    new HotelFacility() { Id = 11, FacilityId = 2, HotelId = 5 }


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

        public DbSet<Image> Images { get; set; }
        public DbSet<HotelFacility> HotelFacilities { get; set; }
        public DbSet<BookingTrip> bookingTrips { get; set; }
        public DbSet<UPDATEBOOKINGTEMP> UPDATEBOOKINGTEMPs { get; set; }

        public DbSet<UPDATEBOOKINGTRIP> UPDATEBOOKINGTRIPs { get; set; }

    }
}
