using System.IO;
using Food.EntityFramework.Configuration;
using Microsoft.Extensions.Configuration;

namespace FoodService.Config
{
    internal class ApplicationConfig
    {
        public DbContextConfiguration DbContextConfiguration => _serviceConfiguration.GetSection("DbContextConfiguration").Get<DbContextConfiguration>();

        private readonly IConfiguration _serviceConfiguration;

        public ApplicationConfig( IConfiguration serviceConfiguration )
        {
            _serviceConfiguration = serviceConfiguration;
        }
    }
}
