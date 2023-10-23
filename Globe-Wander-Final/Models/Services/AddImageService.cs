using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;
using Globe_Wander_Final.Models.Interfaces;
using Globe_Wander_Final.Data;
using Globe_Wander_Final.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using SendGrid.Helpers.Mail;

namespace Globe_Wander_Final.Models.Services
{
    public class AddImageService : IAddImage
    {
        private readonly GlobeWanderDbContext _context;
        private readonly IConfiguration _configuration;

        public AddImageService(IConfiguration configuration, GlobeWanderDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public async Task<TourSpot> UploadImage(IFormFile file, TourSpot Model)
        {
            BlobContainerClient blobContainerClient =
                new BlobContainerClient(_configuration.GetConnectionString("StorageAccount"), "globe-wander-images");

            // Create if images container not exist 
            await blobContainerClient.CreateIfNotExistsAsync();

            BlobClient blobClient = blobContainerClient.GetBlobClient(file.FileName);

            using var fileStream = file.OpenReadStream();

            BlobUploadOptions blobUploadOptions = new BlobUploadOptions()
            {
                HttpHeaders = new BlobHttpHeaders { ContentType = file.ContentType }
            };

            if (!blobClient.Exists())
            {
                await blobClient.UploadAsync(fileStream, blobUploadOptions);
            }
            Model.Img = blobClient.Uri.ToString();

            return Model;

        }

        public async Task<Hotel> UploadHotelImages(List<IFormFile> files, Hotel Model)
        {
            BlobContainerClient blobContainerClient =
                new BlobContainerClient(_configuration.GetConnectionString("StorageAccount"), "globe-wander-images");

            // Create if images container not exist 
            await blobContainerClient.CreateIfNotExistsAsync();

            foreach (var file in files)
            {
                BlobClient blobClient = blobContainerClient.GetBlobClient(file.FileName);

                using var fileStream = file.OpenReadStream();

                BlobUploadOptions blobUploadOptions = new BlobUploadOptions()
                {
                    HttpHeaders = new BlobHttpHeaders { ContentType = file.ContentType }
                };

                if (!blobClient.Exists())
                {
                    await blobClient.UploadAsync(fileStream, blobUploadOptions);
                }
                await AddHotelImage(blobClient.Uri.ToString(), Model);
            }

            return Model;
        }

        public async Task<Image> AddHotelImage(string imageURL, Hotel hotel)
        {
            if (hotel != null && (imageURL != "" || imageURL != null))
            {
                Image newHotelImage = new Image
                {
                    Path = imageURL,
                    HotelId = hotel.Id,
                };
                await _context.Images.AddAsync(newHotelImage);
                await _context.SaveChangesAsync();
                return newHotelImage;
            }
            return null;

        }

        public async Task DeleteHotelRoomImages(int hotelId, int roomNumber)
        {
            var images = await _context.Images.Where(h => h.HotelId == hotelId && h.RoomNumber == roomNumber).ToListAsync();
            if (images.Count > 0)
            {
                foreach (var img in images)
                {
                    _context.Entry(img).State = EntityState.Deleted;
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task<HotelRoomDTO> UploadHotelRoomImages(List<IFormFile> files, HotelRoomDTO Model)
        {
            await DeleteHotelRoomImages(Model.HotelID, Model.HotelID);
            BlobContainerClient blobContainerClient =
              new BlobContainerClient(_configuration.GetConnectionString("StorageAccount"), "globe-wander-images");

            // Create if images container not exist 
            await blobContainerClient.CreateIfNotExistsAsync();

            foreach (var file in files)
            {
                BlobClient blobClient = blobContainerClient.GetBlobClient(file.FileName);

                using var fileStream = file.OpenReadStream();

                BlobUploadOptions blobUploadOptions = new BlobUploadOptions()
                {
                    HttpHeaders = new BlobHttpHeaders { ContentType = file.ContentType }
                };

                if (!blobClient.Exists())
                {
                    await blobClient.UploadAsync(fileStream, blobUploadOptions);
                }
                await AddHotelRoomImage(blobClient.Uri.ToString(), Model);
            }

            return Model;
        }
        public async Task<Image> AddHotelRoomImage(string imageURL, HotelRoomDTO hotelRoom)
        {
            if (hotelRoom != null && (imageURL != "" || imageURL != null))
            {
                Image newHotelImage = new Image
                {
                    Path = imageURL,
                    HotelId = hotelRoom.HotelID,
                    RoomNumber = hotelRoom.RoomNumber,
                };
                await _context.Images.AddAsync(newHotelImage);
                await _context.SaveChangesAsync();
                return newHotelImage;
            }
            return null;

        }

        public async Task<HotelDTO> UpdateHotelImages(List<IFormFile> files, HotelDTO Model)
        {
            await DeleteHotelImages(Model.Id);

            BlobContainerClient blobContainerClient =
               new BlobContainerClient(_configuration.GetConnectionString("StorageAccount"), "globe-wander-images");

            // Create if images container not exist 
            await blobContainerClient.CreateIfNotExistsAsync();
            List<string> imageURL = new List<string>();
            foreach (var file in files)
            {
                BlobClient blobClient = blobContainerClient.GetBlobClient(file.FileName);

                using var fileStream = file.OpenReadStream();

                BlobUploadOptions blobUploadOptions = new BlobUploadOptions()
                {
                    HttpHeaders = new BlobHttpHeaders { ContentType = file.ContentType }
                };

                if (!blobClient.Exists())
                {
                    await blobClient.UploadAsync(fileStream, blobUploadOptions);
                }
                await PutHotelImage(blobClient.Uri.ToString(), Model);
            }

            return Model;
        }

        public async Task DeleteHotelImages(int hotelID)
        {
            var images = await _context.Images.Where(h => h.HotelId == hotelID && h.RoomNumber == null).ToListAsync();
            if (images.Count > 0)
            {
                foreach (var img in images)
                {
                    _context.Entry(img).State = EntityState.Deleted;
                    await _context.SaveChangesAsync();
                }
            }

        }

        public async Task<Image> PutHotelImage(string imageURL, HotelDTO model)
        {

            if (model != null && (imageURL != "" || imageURL != null))
            {
                Image newHotelImage = new Image
                {
                    Path = imageURL,
                    HotelId = model.Id,
                };
                await _context.Images.AddAsync(newHotelImage);
                await _context.SaveChangesAsync();
                return newHotelImage;
            }
            return null;

        }

        public async Task<TripDTO> UploadTripImages(List<IFormFile> files, TripDTO Model)
        {
            BlobContainerClient blobContainerClient =
                new BlobContainerClient(_configuration.GetConnectionString("StorageAccount"), "globe-wander-images");

            // Create if images container not exist 
            await blobContainerClient.CreateIfNotExistsAsync();

            foreach (var file in files)
            {
                BlobClient blobClient = blobContainerClient.GetBlobClient(file.FileName);

                using var fileStream = file.OpenReadStream();

                BlobUploadOptions blobUploadOptions = new BlobUploadOptions()
                {
                    HttpHeaders = new BlobHttpHeaders { ContentType = file.ContentType }
                };

                if (!blobClient.Exists())
                {
                    await blobClient.UploadAsync(fileStream, blobUploadOptions);
                }
                await AddTripImages(blobClient.Uri.ToString(), Model);
            }

            return Model;
        }

        public async Task AddTripImages(string imageURL, TripDTO model)
        {
            if (model != null && (imageURL != "" || imageURL != null))
            {
                Image newHotelImage = new Image
                {
                    Path = imageURL,
                    TripId = model.Id
                };
                await _context.Images.AddAsync(newHotelImage);
                await _context.SaveChangesAsync();

            }
        }



        public async Task<TripDTO> UpdateTripImages(List<IFormFile> files, TripDTO Model)
        {
            await DeleteTripImages(Model.Id);
            BlobContainerClient blobContainerClient =
               new BlobContainerClient(_configuration.GetConnectionString("StorageAccount"), "globe-wander-images");

            // Create if images container not exist 
            await blobContainerClient.CreateIfNotExistsAsync();

            foreach (var file in files)
            {
                BlobClient blobClient = blobContainerClient.GetBlobClient(file.FileName);

                using var fileStream = file.OpenReadStream();

                BlobUploadOptions blobUploadOptions = new BlobUploadOptions()
                {
                    HttpHeaders = new BlobHttpHeaders { ContentType = file.ContentType }
                };

                if (!blobClient.Exists())
                {
                    await blobClient.UploadAsync(fileStream, blobUploadOptions);
                }
                await AddTripImages(blobClient.Uri.ToString(), Model);
            }

            return Model;
        }
        public async Task DeleteTripImages(int id)
        {
            var images = await _context.Images.Where(h => h.TripId == id).ToListAsync();
            if (images.Count > 0)
            {
                foreach (var img in images)
                {
                    _context.Entry(img).State = EntityState.Deleted;
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task<UserUpdateDTO> UpdateProfileImage(IFormFile file, UserUpdateDTO model)
        {

            BlobContainerClient blobContainerClient =
                new BlobContainerClient(_configuration.GetConnectionString("StorageAccount"), "globe-wander-images");

            // Create if images container not exist 

            await blobContainerClient.CreateIfNotExistsAsync();

            BlobClient blobClient = blobContainerClient.GetBlobClient(file.FileName);

            using var fileStream = file.OpenReadStream();

            BlobUploadOptions blobUploadOptions = new BlobUploadOptions()
            {
                HttpHeaders = new BlobHttpHeaders { ContentType = file.ContentType }
            };

            if (!blobClient.Exists())
            {
                await blobClient.UploadAsync(fileStream, blobUploadOptions);
            }

            model.ImageUrl = blobClient.Uri.ToString();


            return model;
        }

    }
}
