using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using TicketApi.Settings;

namespace TicketApi
{
    public class Startup
    {
        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        //public IConfiguration Configuration { get; }
        //public IConfigurationRoot Configuration { get; set; }

        //public Startup()
        //{
        //    var builder = new ConfigurationBuilder()
        //     .AddJsonFile("appsettings.json");

        //    Configuration = builder.Build();
        //}
        private readonly IHostingEnvironment _hostingEnv;

        private IConfigurationRoot Configuration { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="env"></param>
        public Startup(IHostingEnvironment env)
        {
            _hostingEnv = env;

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Info
                    {
                        Version = "v1",
                        Title = "TicketApi",
                        Description = "TicketApi"
                    });
                    c.CustomSchemaIds(type => type.FriendlyId(true));
                    c.DescribeAllEnumsAsStrings();
                    //c.IncludeXmlComments($"{AppContext.BaseDirectory}{Path.DirectorySeparatorChar}{_hostingEnv.ApplicationName}.xml");
                });
            
            services.Configure<DbSettings>(Configuration.GetSection("ConnectionStrings"));
            services.AddOptions();

        }
       

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            loggerFactory
                .AddConsole(Configuration.GetSection("Logging"))
                .AddDebug();
            app
                .UseMvc()
                .UseDefaultFiles()
                .UseStaticFiles()
                .UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "TicketApi");
                });

        }


        //private readonly IHostingEnvironment _hostingEnv;

        //private IConfigurationRoot Configuration { get; }

        ///// <summary>
        ///// Constructor
        ///// </summary>
        ///// <param name="env"></param>
        //public Startup(IHostingEnvironment env)
        //{
        //    _hostingEnv = env;

        //    var builder = new ConfigurationBuilder()
        //        .SetBasePath(env.ContentRootPath)
        //        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        //        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
        //        .AddEnvironmentVariables();
        //    Configuration = builder.Build();
        //}

        ///// <summary>
        ///// This method gets called by the runtime. Use this method to add services to the container.
        ///// </summary>
        ///// <param name="services"></param>
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    // Add framework services.
        //    services
        //        .AddMvc()
        //        .AddJsonOptions(opts =>
        //        {
        //            opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        //            opts.SerializerSettings.Converters.Add(new StringEnumConverter
        //            {
        //                CamelCaseText = true
        //            });
        //        });
            
        //    services
        //        .AddSwaggerGen(c =>
        //        {
        //            c.SwaggerDoc("v1", new Info
        //            {
        //                Version = "v1",
        //                Title = "TicketApi",
        //                Description = "TicketApi (ASP.NET Core 1.0)"
        //            });
        //            c.CustomSchemaIds(type => type.FriendlyId(true));
        //            c.DescribeAllEnumsAsStrings();
        //            c.IncludeXmlComments($"{AppContext.BaseDirectory}{Path.DirectorySeparatorChar}{_hostingEnv.ApplicationName}.xml");
        //        });
        //}

        ///// <summary>
        ///// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        ///// </summary>
        ///// <param name="app"></param>
        ///// <param name="env"></param>
        ///// <param name="loggerFactory"></param>
        //public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        //{
        //    loggerFactory
        //        .AddConsole(Configuration.GetSection("Logging"))
        //        .AddDebug();

        //    app
        //        .UseMvc()
        //        .UseDefaultFiles()
        //        .UseStaticFiles()
        //        .UseSwagger()
        //        .UseSwaggerUI(c =>
        //        {
        //            c.SwaggerEndpoint("/swagger/v1/swagger.json", "TicketApi");
        //        });
        //}
    }
}
