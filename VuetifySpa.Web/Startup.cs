using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VuetifySpa.Data;
using VuetifySpa.Data.Models;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.AspNetCore.Routing;
using VuetifySpa.Data.Services;
using Newtonsoft.Json.Serialization;
using Microsoft.Extensions.Logging;

using Serilog;
using DataTables.AspNet.AspNetCore;

namespace VuetifySpa.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {

            Log.Logger = new LoggerConfiguration()
     .Enrich.FromLogContext()
     .WriteTo.File(string.Format("Logs{0}log.txt", System.IO.Path.DirectorySeparatorChar), rollingInterval: RollingInterval.Hour)
     .CreateLogger();




            var builder = new ConfigurationBuilder()
             .SetBasePath(env.ContentRootPath);
            if (env.IsProduction())
            {
                builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            }
            else
            {
                builder.AddJsonFile($"appsettings.server.json", optional: true);
            }
            builder.AddEnvironmentVariables();
            Configuration = builder.Build();

        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            });
            services.AddLogging(loggingBuilder =>
     loggingBuilder.AddSerilog(dispose: true));

            var connectionString = Configuration.GetConnectionString("PostgreSQL");

            services.AddEntityFrameworkNpgsql()
                .AddDbContext<MyDbContext>((options => options.UseNpgsql(connectionString)));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<MyDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();
            services.AddTransient<UserManager<ApplicationUser>>();
            services.AddTransient<RoleManager<ApplicationUser>>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<ITransportService, TransportService>();
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "neomichi.coockie";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(15);
               
          

            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddTransient<IDesignTimeDbContextFactory<MyDbContext>, MyDbContextDesignTimeDbContextFactory>();

            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                    .AddControllersAsServices()
                    .AddJsonOptions(options =>
                    {
                        options.SerializerSettings.ContractResolver =
                             new CamelCasePropertyNamesContractResolver();
                    });

            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
            services.Configure<RouteOptions>(options => options.AppendTrailingSlash = false);
            // Add Database Initializer->
            services.AddScoped<IDbInitializer, DbInitializer>();
            services.AddSingleton<ILoggerFactory, LoggerFactory>();
            services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
            services.RegisterDataTables();
   
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IDbInitializer dbInitializer,
            ILoggerFactory loggerFactory,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {



            loggerFactory.AddSerilog();


            if (env.IsDevelopment())
            {
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();





            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });




            //Generate EF Core Seed
            dbInitializer.Initialize().Wait();
        }
    }
}
