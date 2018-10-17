using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Food.FoodService.Config
{
    internal static class ApplicationConfig
    {
        public static IConfiguration GetServiceConfiguration()
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
