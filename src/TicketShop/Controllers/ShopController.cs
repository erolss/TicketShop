using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TicketShop.Models.ViewModels;
using TicketShop.RestApiClient;
using TicketShop.Settings;
using ApiModel = TicketShop.RestApiClient.Model;
using TicketShop.RestApiClient.Model;

namespace TicketShop.Controllers
{
    public class ShopController : Controller
    {
        private readonly CustomSettings _apiSettings;

        public ShopController(IOptions<CustomSettings> settings)
        {
            this._apiSettings = settings.Value;

        }


        // GET: Order
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            //list all orders when logged in as user
            return View();
        }


        public ActionResult Events(int offset = 0, int maxLimit = 20)
        {
            var api = new EventApi(_apiSettings.ApiBaseUrl);

            var model = new ShopEventsViewModel
            {
                Events = api.GetEvents(offset, maxLimit)
            };
            ViewData["Title"] = "Events";
            ViewData["ApiBaseUrl"] = _apiSettings.ApiBaseUrl;

            return View(model);
        }

        public ActionResult Event(int id)
        {
            //var api = new EventApi(_apiSettings.ApiBaseUrl);

            //var model = new ShopEventsViewModel();
            //model.Events = new List<Event>();
            //var ev = api.GetEventById(id);
            //model.Events.Add(ev);
            var api = new EventDateApi(_apiSettings.ApiBaseUrl);
            var offset = 0;
            var maxLimit = 30;

            var model = new ShopEventDatesViewModel
            {
                FullEventDates = api.GetFullEventDatesByEventId(id, offset, maxLimit)
            };

            ViewData["ApiBaseUrl"] = _apiSettings.ApiBaseUrl;

           
            return View(model);
        }

        public ActionResult EventDates(int offset = 0, int maxLimit = 20)
        {
            var api = new EventDateApi(_apiSettings.ApiBaseUrl);

            var model = new ShopEventDatesViewModel
            {
                FullEventDates = api.GetFullEventDates(offset, maxLimit)
            };
            ViewData["Title"] = "Upcoming Event Dates";
            ViewData["ApiBaseUrl"] = _apiSettings.ApiBaseUrl;

            return View(model);
        }

        public ActionResult EventDatesByEventId(int eventId, int offset = 0, int maxLimit = 20)
        {
            var api = new EventDateApi(_apiSettings.ApiBaseUrl);

            var model = new ShopEventDatesViewModel
            {
                FullEventDates = api.GetFullEventDatesByEventId(eventId, offset, maxLimit)
            };

            ViewData["ApiBaseUrl"] = _apiSettings.ApiBaseUrl;

            return View("Event", model);
        }

        //public IActionResult EventDate(int eventDateId)
        //{

        //    var api = new EventDateApi(_apiSettings.ApiBaseUrl);

        //    var model = new ShopEventDateViewModel
        //    {
        //        FullEventDate = api.GetFullEventDateById(eventDateId)
        //    };

        //    ViewData["ApiBaseUrl"] = _apiSettings.ApiBaseUrl;

        //    return View(model);
        //}

        public ActionResult Venues(int offset = 0, int maxLimit = 20)
        {
            var api = new VenueApi(_apiSettings.ApiBaseUrl);

            var model = new ShopVenuesViewModel
            {
                Venues = api.GetVenues(offset, maxLimit)
            };
            ViewData["Title"] = "Venues";
            return View(model);
        }

        public ActionResult Venue(int venueId)
        {
            var api = new VenueApi(_apiSettings.ApiBaseUrl);

            var model = new ShopVenueViewModel
            {
                Venue = api.GetVenueById(venueId)
            };

            ViewData["ApiBaseUrl"] = _apiSettings.ApiBaseUrl;

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Find(IFormCollection form)
        {
            var model = new ShopFindViewModel();

            if (!String.IsNullOrEmpty(form["search_param"]))
            {
                var sParam = form["search_param"];
                var query = new ApiModel.Search
                {
                    Searchstring = form["search_query"]
                };



                if (sParam == "eventdate")
                {
                    var api = new EventDateApi(_apiSettings.ApiBaseUrl);
                    model.FullEventDates = api.FindFullEventDates(query);
                    model.PartialView = "_FindEventDatesPartial";
                    ViewData["Title"] = "Event Dates";
                }
                else if (sParam == "venue")
                {
                    var api = new VenueApi(_apiSettings.ApiBaseUrl);
                    model.Venues = api.FindVenues(query);
                    model.PartialView = "_FindVenuesPartial";
                    ViewData["Title"] = "Venues";
                }
                else // sParam == events or something else
                {
                    var api = new EventApi(_apiSettings.ApiBaseUrl);
                    model.Events = api.FindEvents(query);
                    model.PartialView = "_FindEventsPartial";
                    ViewData["Title"] = "Events";
                }
            }

            ViewData["ApiBaseUrl"] = _apiSettings.ApiBaseUrl;

            return View("Find", model);
        }

    }
}