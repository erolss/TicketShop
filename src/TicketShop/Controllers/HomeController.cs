using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TicketShop.Models;
using TicketShop.Settings;
using TicketSystem.RestApiClient;
using ApiModel = TicketSystem.RestApiClient.Model;

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
            var eApi = new EventApi(_apiSettings.ApiBaseUrl);
           // var events = eApi.GetEvents();
            
            return View();
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
