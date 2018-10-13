using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Food.EntityFramework.Context
{
    class FoodDbContext : DbContext
    {
        public DbSet<Entity.User> Users { get; set; }
        public FoodDbContext(DbContextOptions<FoodDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}