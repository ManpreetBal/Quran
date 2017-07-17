using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using QuranClub.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using QuranClub.Core.Services.IServices;
using QuranClub.Core.Services;
using QuranClub.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using cloudscribe.Web.Pagination;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace QuranClub.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        public IConfigurationRoot Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDistributedMemoryCache();
            services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromSeconds(10);
                option.CookieHttpOnly = true;
            }
            );

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
            services.AddApplicationInsightsTelemetry(Configuration);
            services.AddMvc(
                     config =>
                     {
                         config.Filters.Add(typeof(CustomExceptionFilter));
                         config.MaxModelValidationErrors = 500;
                     }
                );
            services.AddDbContext<DBEntities>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("QuranClub.Web"));
                //  options.UseInMemmoryDatabase();
            }
            );
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<ILanguagesService, LanguageService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAdminService, AdminService>();
            services.AddTransient<IApplicationUserService, ApplicationUserService>();
            services.AddTransient<IGroupService, GroupService>();
            services.AddTransient<ICharityService, CharityService>();
            services.AddTransient<ICauseService, CauseService>();
            services.AddTransient<IAdvertSubscriptionService, AdvertSubscriptionService>();
            services.AddTransient<IAdvertService, AdvertService>();
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<IMediaTypeService, MediaTypeService>();
            services.AddTransient<IImageUploadService, ImageUploadService>();
            services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<DBEntities>()
            .AddDefaultTokenProviders();
            services.AddIdentity<ApplicationUser, ApplicationRole>()
            .AddEntityFrameworkStores<DBEntities>()
            .AddDefaultTokenProviders();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
            });
            services.AddCloudscribePagination();
            services.TryAddTransient<IBuildPaginationLinks, PaginationLinkBuilder>();
            services.Configure<IISOptions>(options =>
            {
                options.AutomaticAuthentication = true;
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/AccessDenied"),
                AutomaticChallenge = true
            });
            app.UseStaticFiles();
            app.UseIdentity();
            app.UseSession();
            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715         
            app.UseMvc(routes =>
            {
                // Areas support
                routes.MapRoute("areaRoute", "{area:exists}/{controller=Login}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            await CreateRoles(serviceProvider);
        }
        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            //adding custom roles
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var UserManager = serviceProvider.GetRequiredService<UserManager<Domain.Entities.ApplicationUser>>();

            string[] roleNames = { "Admin", "User" };

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
            //hjkukuhhkh​
            //creating a super user who could maintain the web app
            var poweruser = new Domain.Entities.ApplicationUser

            {
                UserName = Configuration.GetSection("UserSettings")["UserEmail"],
                Email = Configuration.GetSection("UserSettings")["UserEmail"]
            };
            string UserPassword = Configuration.GetSection("UserSettings")["UserPassword"];
            var _user = await UserManager.FindByEmailAsync(Configuration.GetSection("UserSettings")["UserEmail"]);
            if (_user == null)
            {
                var createPowerUser = await UserManager.CreateAsync(poweruser, UserPassword);
                if (createPowerUser.Succeeded)
                {
                    //here we tie the new user to the "Admin" role 
                    await UserManager.AddToRoleAsync(poweruser, "Admin");
                }
            }

        }

    }
}
