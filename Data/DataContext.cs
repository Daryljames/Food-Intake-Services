namespace FoodIntakeServices.Data;

using Microsoft.EntityFrameworkCore;
using FoodIntakeServices.Models;

public class DataContext : DbContext
{
    public DbSet<FoodItem> FoodItems { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FoodItem>()
            .HasOne(f => f.User)
            .WithMany(u => u.FoodItems);
    }
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
}