using Microsoft.EntityFrameworkCore;
using Bhatkanti_.Data;
using Bhatkanti_.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Bhatkanti_.ServicesImpl;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Session;

namespace Bhatkanti_
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    // Use ReferenceHandler.Preserve to handle circular references
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Configure MySQL connection
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<TravelGuideContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            // Register services
            builder.Services.AddScoped<IAdminService, AdminService>();
            builder.Services.AddScoped<ICityService, CityService>();
            builder.Services.AddScoped<ILocationService, LocationServiceImpl>();
            builder.Services.AddScoped<IGuideService, GuideService>();
            builder.Services.AddScoped<IGuideVerificationService, GuideVerificationService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IUserGuideBookingService, UserGuideBookingService>();
            builder.Services.AddScoped<IBillService, BillService>();
            builder.Services.AddScoped<IGuideFeedbackService, GuideFeedbackService>();
            builder.Services.AddScoped<IPlaceFeedbackService, PlaceFeedbackServiceImpl>();
            builder.Services.AddScoped<IWishlistService, WishlistServiceImpl>();

            // Configure session management
            builder.Services.AddDistributedMemoryCache(); // Adds a default in-memory implementation of IDistributedCache
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Set the session timeout
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            // Enable CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:3000") // Replace with your React app's URL
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                    });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            // Use session
            app.UseSession();

            // Use CORS
            app.UseCors("AllowReactApp");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}