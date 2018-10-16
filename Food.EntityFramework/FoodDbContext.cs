using Microsoft.EntityFrameworkCore;
using Food.EntityFramework.Entities.Configurations;
using Food.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Food.EntityFramework.Context
{
    internal sealed class FoodDbContext : DbContext
    {
    
        public DbSet<Container> Containers { get; set; }
        public DbSet<Dish> Dishs { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public FoodDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=mobileappdb2;Trusted_Connection=True;");
        }

        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            modelBuilder.ApplyConfiguration(new ContainerConfiguration());
            modelBuilder.ApplyConfiguration(new DishConfiguration());
            modelBuilder.ApplyConfiguration(new MenuConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}