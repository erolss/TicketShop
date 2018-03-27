using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TicketShop.Areas.Admin.Models;
using TicketShop.Models.ViewModels;
using TicketShop.RestApiClient;
using TicketShop.RestApiClient.Model;
using TicketShop.Settings;

namespace TicketShop.Areas.Admin.Controllers
{
    [Authorize(Policy = "RequireAdminRole")]
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly CustomSettings _apiSettings;

        public AdminController(IOptions<CustomSettings> settings)
        {
            this._apiSettings = settings.Value;

        }
        public IActionResult Find()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Find(IFormCollection form)
        {
            var model = new FindViewModel();

            if (!String.IsNullOrEmpty(form["search_param"]))
            {
                var sParam = form["search_param"];
                var query = new Search
                {
                    Searchstring = form["search_query"]
                };

                model.SearchParam = sParam;

                var eApi = new EventApi(_apiSettings.ApiBaseUrl);
                model.Events = eApi.FindEvents(query);
                var edApi = new EventDateApi(_apiSettings.ApiBaseUrl);
                model.EventDates = edApi.FindEventDates(query);
                var vApi = new VenueApi(_apiSettings.ApiBaseUrl);
                model.Venues = vApi.FindVenues(query);

                if (sParam == "eventdate")
                {
                    model.PartialView = "_FindEventDatesPartial";
                    ViewData["Title"] = "Event Dates";
                }
                else if (sParam == "venue")
                {
                    model.PartialView = "_FindVenuesPartial";
                    ViewData["Title"] = "Venues";
                }
                else // sParam == events or something else
                {
                    model.PartialView = "_FindEventsPartial";
                    ViewData["Title"] = "Events";
                }
            }
            return View("Find", model);
        }
    }
}