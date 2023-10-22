using Globe_Wander_Final.Data;
using Globe_Wander_Final.Models;
using Globe_Wander_Final.Models.Interfaces;
using Globe_Wander_Final.Models.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Globe_Wander_Final
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorPages();

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

            string? connString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services
                .AddDbContext<GlobeWanderDbContext>
                (options=>options.UseSqlServer(connString));

            builder.Services.AddControllers().AddNewtonsoftJson(option =>
            {
                option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>
                (options =>
                {
                    options.User.RequireUniqueEmail = true;
                }).AddEntityFrameworkStores<GlobeWanderDbContext>();
             

                builder.Services.AddAuthentication();

                builder.Services.AddAuthorization(options => {
                options.AddPolicy("create", policy => policy.RequireClaim("persmissions", "create"));
                options.AddPolicy("update", policy => policy.RequireClaim("persmissions", "update"));
                options.AddPolicy("delete", policy => policy.RequireClaim("persmissions", "delete"));
                options.AddPolicy("read", policy   => policy.RequireClaim("persmissions", "read"));
            });

            builder.Services.AddTransient<ITourSpot, TourSpotService>();
            builder.Services.AddTransient<ITrip, TripService>();
            builder.Services.AddTransient<IHotel, HotelService>();
            builder.Services.AddTransient<IHotelRoom, HotelRoomService>();
            builder.Services.AddTransient<IRoom, RoomService>();
            builder.Services.AddTransient<IBookingRoom, BookingRoomService>();
            builder.Services.AddTransient<IBookingTrip, BookingTripService>();
            builder.Services.AddTransient<IRate, RateService>();
            builder.Services.AddTransient<IUser, IdentityUserService>();

            builder.Services.AddTransient<EmailService>();

            builder.Services.AddTransient<IAddImage, AddImageService>();

            builder.Services.AddTransient<UPDATEBOOKINGTEMPServices>();

            builder.Services.AddAuthorization();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/User/Login"; // Set the correct path to your login action
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            //app.UseCookiePolicy();
            app.MapRazorPages();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
