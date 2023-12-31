﻿using Globe_Wander_Final.Models.DTOs;
using Globe_Wander_Final.Models.Interfaces;
using Globe_Wander_Final.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace Globe_Wander_Final.Controllers
{
    
    public class TripsController : Controller
    {
        private readonly ITrip _trips;
        private readonly ITourSpot _tour;
        private readonly IAddImage _upload;

        public TripsController(ITrip trips, ITourSpot tour, IAddImage upload)
        {
            _trips = trips;
            _tour = tour;
            _upload = upload;
        }

        //TODO: remove the filter & list type & edit the design column it should be container & maximum traveler first one remove  remove the id - yaman - done
        public async Task<IActionResult> Trips(int? page)
        {
            int pageSize = 6; // Set your desired page size here.
            int pageNumber = page ?? 1; // Default to the first page if no page number is provided.

            var allTrips = await _trips.GetAllTrips();
            
            // Create a paged list of trips based on the requested page and page size.
            var pagedList = allTrips.ToPagedList(pageNumber, pageSize);

            return View(pagedList);
        }
        //TODO: Home/detail edit the posistion & comment should be vaildated & remove the trip id & fix the depature and arrive time & rate star shuld be calculated - yaman
        public async Task<IActionResult> TripDetails(int id)
        {

            var trip = await _trips.GetTripByID(id);
            var trips = await _trips.GetAllTrips();
            var tripAndRecomanded = new RecomandedTripsAndTrip
            {
                trip = trip,
                ListTrips = trips
            };
            return View(tripAndRecomanded);
        }

        [Authorize(Roles = "Trip Manager, Admin Manager")]
        public async Task<IActionResult> ListTrips(int? page)
        {
            int pageSize = 6;

            int pageNumber = page ?? 1;

            var trips = await _trips.GetAllTrips();

            var pagedList = trips.ToPagedList(pageNumber, pageSize);

            return View(pagedList);
        }

        [Authorize(Roles = "Trip Manager, Admin Manager")]
        public async Task<IActionResult> CreateTrip()
        {
            var tours = await _tour.GetAllTourSpots();

            ViewBag.Tours = tours;

            return View();
        }

        [Authorize(Roles = "Trip Manager , Admin Manager")]
        [HttpPost]
        public async Task<IActionResult> CreateTrip(NewTripDTO model,List<IFormFile> files)
        {
            if (ModelState.IsValid)
            {
                var trip = await _trips.CreateTrip(model);

                if (trip != null)
                {
                    if (files.Count > 0)
                    {
                        await _upload.UploadTripImages(files, trip);
                    }
                    return RedirectToAction("ListTrips", "Trips");
                }
                return View(model);
            }
            else
            {
                return View();
            }
        }

        [Authorize(Roles = "Trip Manager , Admin Manager")]
        public async Task<IActionResult> EditTrip(int id)
        {
            var trip = await _trips.GetTripByID(id);
            var tours = await _tour.GetAllTourSpots();

            ViewBag.Tours = tours;

            return View(trip);
            
        }

        [Authorize(Roles = "Trip Manager , Admin Manager")]
        [HttpPost]
        public async Task<IActionResult> EditTrip(NewTripDTO model, int id, List<IFormFile> files)
        {
            if (ModelState.IsValid)
            {
                var trip = await _trips.UpdateTrip(model, id); 

                if (files.Count > 0)
                {
                    await _upload.UpdateTripImages(files,trip);
                }

                return RedirectToAction("ListTrips", "Trips");
            }
            var tours = await _tour.GetAllTourSpots();

            ViewBag.Tours = tours;
            return View(model);
        }

        [Authorize(Roles = "Trip Manager , Admin Manager")]
        [HttpPost]
        public async Task<IActionResult> DeleteTrip(int id)
        {
            await _trips.DeleteTrip(id);
            return RedirectToAction("ListTrips", "Trips");
        }

    }
}
