using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace TicketApi
{
    public class Program
    {
        //public static void Main(string[] args)
        //{
        //    BuildWebHost(args).Run();
        //}

        //public static IWebHost BuildWebHost(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args)
        //        .UseStartup<Startup>()
        //        .Build();
        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel(options =>
                {
                    // options.ThreadCount = 4;
                    // options.UseHttps("cert.pfx", "certpassword");
                    options.Listen(IPAddress.Any, 80, listenOptions =>
                    {
                        listenOptions.NoDelay = false;
                        listenOptions.UseConnectionLogging();
                    });
                    //options.NoDelay = true;
                    //options.UseConnectionLogging();
                })
                .UseUrls("http://+:5000" /*, "https://+:5001" */)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();

        }
    }
}
