using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TicketShop.Models;
using TicketShop.Models.ViewModels;
using TicketShop.Settings;
using TicketShop.RestApiClient;
using ApiModel = TicketShop.RestApiClient.Model;

namespace TicketShop.Controllers
{
    public class HomeController : Controller
    {
        private CustomSettings _apiSettings;


        public HomeController(IOptions<CustomSettings> settings)
        {
            this._apiSettings = settings.Value;

        }

        public IActionResult Index()
        {
            var api = new EventDateApi(_apiSettings.ApiBaseUrl);

            var model = new HomeIndexViewModel
            {
                FullEventDates = api.GetFullEventDates()
            };

            ViewData["ApiBaseUrl"] = _apiSettings.ApiBaseUrl;

            return View(model);
        }

        public IActionResult Events(int offset = 0, int maxLimit = 20)
        {
            var api = new EventApi(_apiSettings.ApiBaseUrl);

            var model = new HomeEventsViewModel
            {
                Events = api.GetEvents(offset, maxLimit)
            };

            ViewData["ApiBaseUrl"] = _apiSettings.ApiBaseUrl;

            return View(model);
        }

        public IActionResult Event(int eventId)
        {
            var api = new EventApi(_apiSettings.ApiBaseUrl);

            var model = new HomeEventViewModel
            {
                Event = api.GetEventById(eventId)
            };

            ViewData["ApiBaseUrl"] = _apiSettings.ApiBaseUrl;

            return View(model);
        }

        public IActionResult EventDates(int offset = 0, int maxLimit = 20)
        {
            var api = new EventDateApi(_apiSettings.ApiBaseUrl);

            var model = new HomeEventDatesViewModel
            {
                FullEventDates = api.GetFullEventDates(offset, maxLimit)
            };
            ViewData["ApiBaseUrl"] = _apiSettings.ApiBaseUrl;

            return View(model);
        }

        public IActionResult EventDatesByEventId(int eventId, int offset = 0, int maxLimit = 20)
        {
            var api = new EventDateApi(_apiSettings.ApiBaseUrl);

            var model = new HomeEventDatesViewModel
            {
                FullEventDates = api.GetFullEventDatesByEventId(eventId, offset, maxLimit)
            };

            ViewData["ApiBaseUrl"] = _apiSettings.ApiBaseUrl;

            return View("EventDates", model);
        }

        public IActionResult EventDate(int eventDateId)
        {

            var api = new EventDateApi(_apiSettings.ApiBaseUrl);

            var model = new HomeEventDateViewModel
            {
                FullEventDate = api.GetFullEventDateById(eventDateId)
            };

            ViewData["ApiBaseUrl"] = _apiSettings.ApiBaseUrl;

            return View(model);
        }

        public IActionResult Venues(int offset = 0, int maxLimit = 20)
        {
            var api = new VenueApi(_apiSettings.ApiBaseUrl);

            var model = new HomeVenuesViewModel
            {
                Venues = api.GetVenues(offset, maxLimit)
            };

            return View(model);
        }

        public IActionResult Venue(int venueId)
        {
            var api = new VenueApi(_apiSettings.ApiBaseUrl);

            var model = new HomeVenueViewModel
            {
                Venue = api.GetVenueById(venueId)
            };

            ViewData["ApiBaseUrl"] = _apiSettings.ApiBaseUrl;

            return View(model);
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
