using Bhatkanti.Models;
using Bhatkanti.Services;
using Bhatkanti.ServicesImpl;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Text.Json;
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace Bhatkanti
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            builder.Services.AddMemoryCache();

            // Configure Swagger/OpenAPI
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Configure database context
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
                new MySqlServerVersion(new Version(8, 0, 36))));

            // Configure JSON options
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                });

            // Configure CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    policyBuilder =>
                    {
                        policyBuilder.AllowAnyOrigin()
                                     .AllowAnyMethod()
                                     .AllowAnyHeader();
                    });
            });

            // Configure Authentication
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/api/user/login"; // Redirect here if not authenticated
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Adjust expiration as needed
                options.Cookie.HttpOnly = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Use Always in production
                
            });

            // Configure Dependency Injection for Services
            builder.Services.AddScoped<IUserService, UserServiceImpl>();
            builder.Services.AddScoped<IProfileService, ProfileServiceImpl>();
            builder.Services.AddScoped<IRoleService, RoleServiceImpl>();
            builder.Services.AddScoped<ICityService, CityServiceImpl>();
            builder.Services.AddScoped<IPlaceService, PlaceServiceImpl>();
            builder.Services.AddScoped<IImageService, ImageServiceImpl>();
            builder.Services.AddScoped<IPlaceFeedbackService, PlaceFeedbackServiceImpl>();
            builder.Services.AddScoped<IBookingPaymentDetailService, BookingPaymentDetailServiceImpl>();
            builder.Services.AddScoped<IWishlistService, WishlistServiceImpl>();
            builder.Services.AddScoped<IGuideService, GuideServiceImpl>();
            builder.Services.AddScoped<IBillService, BillServiceImpl>();
            builder.Services.AddScoped<IHelpService,HelpServiceImpl>();
            builder.Services.AddScoped<IPlaceImageService, PlaceImageServiceImpl>();
            builder.Services.AddScoped<IPlaceService, PlaceServiceImpl>();
            builder.Services.AddScoped<IUserGuideBookingsService, UserGuideBookingsServiceImpl>();

            builder.Services.AddScoped<IFeedbackService,FeedbackServiceImpl>();

            builder.Services.AddScoped<IBookingPlaceGuideService,BookingPlaceGuideServiceImpl>();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            

            app.UseHttpsRedirection();

            app.UseCors("AllowAllOrigins");

            // Add authentication and authorization middleware
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseRouting();
            

            app.MapControllers();

            app.Run();
        }
    }
}
