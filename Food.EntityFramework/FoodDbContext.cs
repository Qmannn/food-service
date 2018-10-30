using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using System.Linq;

namespace Food.EntityFramework.Context
{
    public class FoodDbContext : DbContext
    {
        public FoodDbContext()
        {
            Database.EnsureCreated();
        }

        public FoodDbContext(DbContextOptions<FoodDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=mobileappdb2;Trusted_Connection=True;");
        }

        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            base.OnModelCreating(modelBuilder);

            var typesToRegister = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.GetInterfaces().Any(gi => gi.IsGenericType && gi.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)))
                .ToList();


            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }
        }
    }
}