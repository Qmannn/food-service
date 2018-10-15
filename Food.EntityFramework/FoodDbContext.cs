using Microsoft.EntityFrameworkCore;
using Food.EntityFramework.Entities;

namespace Food.EntityFramework.Context
{
    internal sealed class FoodDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}