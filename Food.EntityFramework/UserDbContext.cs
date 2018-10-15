using Microsoft.EntityFrameworkCore;
using Food.EntityFramework.Entities;

namespace Food.EntityFramework.Context
{
    internal class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}