using Microsoft.EntityFrameworkCore;
using FoodIntakeServices.Interfaces;
using FoodIntakeServices.Services;
using FoodIntakeServices.Data;
using System.Text.Json.Serialization;

namespace FoodIntakeServices
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            var corsConfigName = "CORS-Config";
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: corsConfigName, policy =>
                {
                    policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
                });
            });
            // bootstraps the neccessary dependencies

            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.WriteIndented = true;
            });

            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("MSSqlConnection"));
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IFoodItemsService, FoodItemsMSSQLService>();

            builder.Services.AddScoped<IUsersService, UsersMSSQLService>();

            builder.Services.AddScoped<IMealsService, MealsMSSQLService>();

            WebApplication app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(corsConfigName);

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}


