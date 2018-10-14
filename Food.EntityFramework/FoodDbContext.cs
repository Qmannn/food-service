using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Food.EntityFramework.Context
{
    internal class FoodDbContext : DbContext
    {
        public DbSet<Entities.User> Users { get; set; }
    }
}