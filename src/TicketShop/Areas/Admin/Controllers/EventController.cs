using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiModel = TicketShop.RestApiClient.Model;
using TicketShop.Areas.Admin.Models;
using TicketShop.Models;
using TicketShop.Settings;
using Microsoft.Extensions.Options;
using TicketShop.RestApiClient;
using TicketShop.RestApiClient.Model;

namespace TicketShop.Areas.Admin.Controllers
{
    [Authorize(Policy = "RequireAdminRole")]
    [Area("Admin")]
    public class EventController : Controller
    {
        private readonly CustomSettings _apiSettings;

        public EventController(IOptions<CustomSettings> settings)
        {
            this._apiSettings = settings.Value;

        }
        // GET: Event
        public ActionResult Index(int offset=0, int maxLimit=30)
        {
            var api = new EventApi(_apiSettings.ApiBaseUrl);

            var model = new EventsViewModel
            {
                Events = api.GetEvents(offset, maxLimit)
            };
            ViewData["Title"] = "Events";
            ViewData["ApiBaseUrl"] = _apiSettings.ApiBaseUrl;

            return View(model);
            
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Event item)
        {
            try
            {
                var api = new EventApi(_apiSettings.ApiBaseUrl);

                var model = api.AddEvent(item);

                ViewData["Title"] = "Events";
                ViewData["ApiBaseUrl"] = _apiSettings.ApiBaseUrl;

                //return View(model);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Event/Edit/5
        public ActionResult Edit(int id)
        {
            var api = new EventApi(_apiSettings.ApiBaseUrl);

            var model = api.GetEventById(id);

            ViewData["Title"] = "Events";
            ViewData["ApiBaseUrl"] = _apiSettings.ApiBaseUrl;

            return View(model);
        }

        // POST: Event/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Event e)
        {
            try
            {
                var api = new EventApi(_apiSettings.ApiBaseUrl);

                var model = api.UpdateEvent(e);

                ViewData["Title"] = "Events";
                ViewData["ApiBaseUrl"] = _apiSettings.ApiBaseUrl;

                

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Event/Delete/5
        public ActionResult Delete(int id)
        {
            var api = new EventApi(_apiSettings.ApiBaseUrl);

            var model = api.DeleteEvent(id);

            return RedirectToAction(nameof(Index));
            
        }

        // POST: Event/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}