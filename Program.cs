using Microsoft.EntityFrameworkCore;
using FoodIntakeServices.Interfaces;
using FoodIntakeServices.Services;
using FoodIntakeServices.Data;

namespace FoodIntakeServices
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            // bootstraps the neccessary dependencies

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("MSSqlConnection"));
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IFoodItemsService, FoodItemsMSSQLService>();

            builder.Services.AddScoped<IUsersService, UsersMSSQLService>();

            WebApplication app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}


