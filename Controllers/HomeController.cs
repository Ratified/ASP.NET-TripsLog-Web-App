using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TripLog.Models;

namespace TripLog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TripContext _dbContext;

        public HomeController(ILogger<HomeController> logger, TripContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            // Fetch trip data from the database
            var trips = _dbContext.Trips
                .Include(t => t.ThingsToDo) // Ensure related data is included
                .ToList();

            // Pass trip data to the view
            ViewBag.SuccessMessage = TempData["SuccessMessage"];
            return View(trips);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}