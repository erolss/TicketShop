using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketShop.Data;
using TicketShop.Models;
using TicketShop.Services;
using TicketShop.Settings;

namespace TicketShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
            });
            services.Configure<CustomSettings>(Configuration.GetSection("ApiSettings"));
            services.AddOptions();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "areaRoute",
                    template: "{area:exists}/{controller=Home}/{action=Index}");

                routes.MapRoute(
                    name: "default",                    
                    template: "{controller=Home}/{action=Index}/{id?}");
                
            });
            CreateRoles(serviceProvider, env).Wait();
        }

        private async Task CreateRoles(IServiceProvider serviceProvider, IHostingEnvironment env)
        {
            //adding customs roles
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            string[] roleNames = { "Admin", "Manager", "Member" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                //creating the roles and seeding them to the database
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            //creating a super user who could maintain the web app
            var poweruser = new ApplicationUser();
            string userPassword;
            if (env.IsProduction())
            {
                poweruser.UserName = Environment.GetEnvironmentVariable("APPSETTING_powerUserEmail");
                poweruser.Email = Environment.GetEnvironmentVariable("APPSETTING_powerUserEmail");
                userPassword = Environment.GetEnvironmentVariable("APPSETTING_powerUserPassword");
            } else
            {
                poweruser.UserName = Configuration.GetSection("AppSettings")["UserEmail"];
                poweruser.Email = Configuration.GetSection("AppSettings")["UserEmail"];
                userPassword = Configuration.GetSection("AppSettings")["UserPassword"];
            }
            
            var user = await UserManager.FindByEmailAsync(poweruser.Email);

            if (user == null)
            {
                var createPowerUser = await UserManager.CreateAsync(poweruser, userPassword);
                if (createPowerUser.Succeeded)
                {
                    //here we tie the new user to the "Admin" role 
                    await UserManager.AddToRoleAsync(poweruser, "Admin");
                }
            }
            else if(!await UserManager.IsInRoleAsync(user,"Admin"))
            {
                await UserManager.AddToRoleAsync(user, "Admin");
            }
        }

    }
}
