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
   new Hotel() { Id = 1, TourSpotID = 1, Name = "Harmony", Location = "amman", StarRate = 4, Description = "A peaceful retreat in the heart of the city" },
    new Hotel() { Id = 2, TourSpotID = 2, Name = "Adventure", Location = "wadi rum", StarRate = 3, Description = "The perfect base for your desert adventure" },
    new Hotel() { Id = 3, TourSpotID = 3, Name = "Oasis", Location = "dead sea", StarRate = 5, Description = "A luxury resort on the shores of the Dead Sea" },
    new Hotel() { Id = 4, TourSpotID = 1, Name = "Heritage", Location = "jerash", StarRate = 4, Description = "Experience the rich history of Jerash" },
    new Hotel() { Id = 5, TourSpotID = 2, Name = "Horizon", Location = "aqaba", StarRate = 5, Description = "Stunning sea views in a modern setting" }

);
            modelBuilder.Entity<HotelRoom>().HasData(
       new HotelRoom { RoomNumber = 101, HotelID = 1,RoomID = 1, Description = " A spacious room with a king-size bed, modern amenities, and a beautiful city view.", SquareFeet = 500, Bathrooms = 1, Beds = 2,PricePerDay = 150.00m, IsAvailable = true },
    new HotelRoom { RoomNumber = 102, HotelID = 1, RoomID = 2, Description = " A luxurious suite with two queen-size beds, a mini bar, a private balcony with ocean views, and premium toiletries.", SquareFeet = 700, Bathrooms = 2,Beds = 2, PricePerDay = 200.00m, IsAvailable = true },
    new HotelRoom {  RoomNumber = 103, HotelID = 1, RoomID = 3, Description = "A large studio with a separate living area, king-size bed, two bathrooms, and a private terrace overlooking the city.", SquareFeet = 1000, Bathrooms = 2, Beds = 1,PricePerDay = 300.00m,  IsAvailable = true },

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
                  new Image { Id = 3, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg",  HotelId = 1 },
                      new Image { Id = 4, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg",HotelId = 1 },
                          new Image { Id = 5, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg",  HotelId = 1 },
                           new Image { Id = 6, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", HotelId = 1 },
                      new Image { Id = 7, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", HotelId = 1 },


              new Image { Id = 8, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel2image2.jpg",  HotelId = 2 },
                      new Image { Id =9, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel2image1.jpg", HotelId = 2 },
                  new Image { Id = 10, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel2image3.jpg", HotelId = 2 },
                      new Image { Id = 11, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel2image4.jpg",  HotelId = 2 },
                          new Image { Id = 12, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel2image5.jpg",HotelId = 2 },
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
              new Image { Id =51, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", HotelId = 1, RoomNumber = 103 },
              new Image { Id = 52, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", HotelId = 1, RoomNumber = 103 },
                      new Image { Id = 53, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", HotelId = 1, RoomNumber = 103},
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
                      new Image { Id =132 , Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", HotelId = 5, RoomNumber = 502 },
       new Image { Id = 133, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", HotelId = 5, RoomNumber = 502 },
         


                            new Image { Id = 134, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", HotelId = 5, RoomNumber = 503 },
                new Image { Id = 135, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", HotelId = 5, RoomNumber = 503 },
              new Image { Id = 136, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", HotelId = 5, RoomNumber = 503 },
              new Image { Id = 137, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", HotelId = 5, RoomNumber = 503 },
                      new Image { Id = 138, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", HotelId = 5, RoomNumber = 503 },
                          new Image { Id = 139, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", HotelId = 5, RoomNumber = 503 },
       new Image { Id = 140, Path = "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", HotelId = 5, RoomNumber = 503 }




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
    }
}
