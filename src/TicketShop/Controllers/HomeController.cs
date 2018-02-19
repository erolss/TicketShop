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
        private readonly CustomSettings _apiSettings;

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
