using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Food.EntityFramework;
using FoodService.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FoodService
{
    public class FoodDbContextFactory : IDesignTimeDbContextFactory<FoodDbContext>
    {
        public FoodDbContext CreateDbContext(string[] args)
        {
            ApplicationConfig config = new ApplicationConfig( GetServiceConfiguration() );
            return new FoodDbContext(config.DbContextConfiguration);
        }

        private IConfiguration GetServiceConfiguration()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false); 


            string additioonalCofigFile = $"appsettings.json";
            if (File.Exists(additioonalCofigFile))
            {
                configurationBuilder.AddJsonFile(additioonalCofigFile, false);
            }

            return configurationBuilder.Build();
        }
    }
}
