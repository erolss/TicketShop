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

namespace TicketShop.Areas.Admin.Controllers
{
    [Authorize(Policy = "RequireAdminRole")]
    [Area("Admin")]
    public class EventDateController : Controller
    {
        // GET: EventDate
        public ActionResult Index()
        {
            return View();
        }

        // GET: EventDate/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EventDate/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventDate/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EventDate/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EventDate/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EventDate/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EventDate/Delete/5
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