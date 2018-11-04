using System;
using System.Linq;
using System.Reflection;
using Food.EntityFramework.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Food.EntityFramework
{
    public class FoodDbContext : DbContext
    {
        private readonly DbContextConfiguration _configuration;

        public FoodDbContext( DbContextConfiguration configuration )
        {
            _configuration = configuration;
        }

        public FoodDbContext(DbContextOptions<FoodDbContext> options, DbContextConfiguration configuration ) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer( _configuration.ConnectionString );
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