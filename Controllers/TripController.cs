using Microsoft.AspNetCore.Mvc;
using TripLog.Models;
using Newtonsoft.Json;

namespace TripLog.Controllers
{
    public class TripController : Controller
    {
        private readonly TripContext _dbContext;

        public TripController(TripContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: /Trip/Add
        public IActionResult Add()
        {
            return View("Add");
        }

        // POST: /Trip/Add/Page2
        [HttpPost]
        public IActionResult AddPage2(Trip trip)
        {
            // Save trip data in TempData
            TempData["Trip"] = JsonConvert.SerializeObject(trip);
            return View("AddPage2");
        }

        // POST: /Trip/Add/Page3
        [HttpPost]
        public IActionResult AddPage3(TripPage2ViewModel viewModel)
        {
            // Save page 2 data in TempData
            TempData["TripPage2"] = JsonConvert.SerializeObject(viewModel);
            return View("AddPage3");
        }

        [HttpPost]
        public IActionResult SaveTrip(TripPage3ViewModel viewModel)
        {
            // Retrieve data from TempData
            var tripJson = TempData["Trip"] as string;
            var tripPage2Json = TempData["TripPage2"] as string;

            if (!string.IsNullOrEmpty(tripJson) && !string.IsNullOrEmpty(tripPage2Json))
            {
                var trip = JsonConvert.DeserializeObject<Trip>(tripJson);
                var tripPage2 = JsonConvert.DeserializeObject<TripPage2ViewModel>(tripPage2Json);

                // Combine the data from all pages
                trip.PhoneNumber = tripPage2.PhoneNumber;
                trip.Email = tripPage2.Email;

                // Create ThingToDo objects from the viewModel strings
                trip.ThingsToDo = new List<ThingToDo>
                {
                    new ThingToDo { Description = viewModel.Thing1 },
                    new ThingToDo { Description = viewModel.Thing2 },
                    new ThingToDo { Description = viewModel.Thing3 },
                };

                // Save trip to the database
                _dbContext.Trips.Add(trip);
                _dbContext.SaveChanges();

                // Store success message in TempData to display on the Home page
                TempData["SuccessMessage"] = "Trip has been successfully added!";
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
