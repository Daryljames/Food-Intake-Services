namespace FoodIntakeServices.Data;

using Microsoft.EntityFrameworkCore;
using FoodIntakeServices.Models;

public class DataContext : DbContext
{
    public DbSet<FoodItem> FoodItems { get; set; }
    public DbSet<User> Users { get; set; }
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
}