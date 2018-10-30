using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace FoodService
{
    public class FoodDbContextFactory : IDesignTimeDbContextFactory<FoodDbContext>
    {
        public FoodDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<FoodDbContext>();
            builder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=mobileappdb2;Trusted_Connection=True;");

            return new FoodDbContext(builder.Options);
        }
    }
}
