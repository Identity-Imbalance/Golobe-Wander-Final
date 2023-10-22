using Globe_Wander_Final.Models;
using Globe_Wander_Final.Models.DTOs;
using Globe_Wander_Final.Models.Interfaces;
using Globe_Wander_Final.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;

namespace Globe_Wander_Final.Controllers
{
    public class HotelsController : Controller
    {
        private readonly IHotel _hotels;

        private readonly ITourSpot _tourSpot;

        private readonly IAddImage _uploadImage;


        public HotelsController(IHotel hotels, ITourSpot tourSpot, IAddImage uploadImage)
        {
            _hotels = hotels;
            _tourSpot = tourSpot;
            _uploadImage = uploadImage;
        }
        public  async Task<IActionResult> Index()
        {
            var hotels =await _hotels.GetAllHotels();
            return View(hotels);
        }

        public async Task<IActionResult> Hotel()
        {
            var hotels = await _hotels.GetAllHotels();
            return View(hotels);
        }


        public async Task<IActionResult> SingleHotel(int Id)
        {
            var hotel = await _hotels.GetHotelId(Id);
            var hotels = await _hotels.GetAllHotels();
            var reco =new RecomandHotelsANDHotelMV()
            {hotel = hotel,
            recomandedHotels = hotels

            };
            return View(reco);
        }

        public async Task<IActionResult> CreateHotel()
        {
            var tourSpots = await _tourSpot.GetAllTourSpots();

            var facilities = await _hotels.GetAllFacilities();

            // Store the tour spots in ViewBag to pass it to the view
            ViewBag.TourSpots = tourSpots;
            ViewBag.Facilities = facilities;

            return View();
        }

        public async Task<IActionResult> ListHotels()
        {
            var hotels = await _hotels.GetAllHotels();
            return View(hotels);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateHotel(NewHotelDTO hotel, List<int> selectedFacilityIds,List<IFormFile> files)
        {
            if (ModelState.IsValid)
            {
                var newHotel = await _hotels.CreateHotel(hotel);
                var existingHotelFacilities = await _hotels.GetAllHotelFacilityByHotelId(newHotel.Id);
                foreach (var facilityId in selectedFacilityIds)
                {
                    if (!existingHotelFacilities.Any(hf => hf.FacilityId == facilityId))
                    {
                        var newHotelFacility = new HotelFacility
                        {
                            FacilityId = facilityId,
                            HotelId = newHotel.Id,
                        };
                        await _hotels.AddHotelFacility(newHotelFacility);
                    }
                }

                if (files.Count > 0)
                {
                    await _uploadImage.UploadHotelImages(files,newHotel);
                }

                return RedirectToAction("CreateHotel","Hotels");
            }
            else
            {
                var tourSpots = await _tourSpot.GetAllTourSpots();

                var facilities = await _hotels.GetAllFacilities();

                // Store the tour spots in ViewBag to pass it to the view
                ViewBag.TourSpots = tourSpots;
                ViewBag.Facilities = facilities;
                return View();
            }
        }

        public async Task<IActionResult> EditHotel(int id)
        {
            var hotel = await _hotels.GetHotelId(id);
            var tourSpots = await _tourSpot.GetAllTourSpots();
            var facilities = await _hotels.GetAllFacilities();

            // Store the tour spots in ViewBag to pass it to the view
            if (hotel  == null)
            {
                return NotFound();
            }
            ViewBag.TourSpots = tourSpots;
            ViewBag.Facilities = facilities;
            return View(hotel);
        }

        // TODO: Make the facilits came from the database and Make the admin choose which one he should add 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditHotel(HotelDTO model, List<int> selectedFacilityIds, List<IFormFile> images)
        {
            var existingHotelFacilities = await _hotels.GetAllHotelFacilityByHotelId(model.Id);

            foreach (var facilityId in selectedFacilityIds)
            {
                if (!existingHotelFacilities.Any(hf=>hf.FacilityId == facilityId))
                {
                    var newHotelFacility = new HotelFacility
                    {
                        FacilityId = facilityId,
                        HotelId = model.Id,
                    };
                    await _hotels.AddHotelFacility(newHotelFacility);
                }
            }
            foreach (var existHotelFacility in existingHotelFacilities)
            {
                if (!selectedFacilityIds.Contains(existHotelFacility.FacilityId))
                {
                    await _hotels.RemoveHotelFacility(existHotelFacility);
                }
            }
           
            var updatedHotel = await _hotels.UpdateHotel(model.Id, model); 
            if (updatedHotel != null)
            {
                if (images.Count > 0)
                {
                    await _uploadImage.UpdateHotelImages(images, updatedHotel);
                }
                return RedirectToAction("EditHotel", "Hotels");
            }

            // If ModelState is not valid, return the view with the model
            return View();
        }

        //public async Task<IActionResult> DeleteHotel()
        //{
        //    return View();
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteHotel(int id)
        {
                var deletedHotel = await _hotels.DeleteHotel(id);
          
                return RedirectToAction("ListHotels","Hotels");
          
        }



    }
}
