using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Food.FoodService.Config
{
    internal static class ApplicationConfig
    {
        public static IConfiguration GetServiceConfiguration()
        {
            string env = Environment.GetEnvironmentVariable("ASPNETCORE_RUNTIME_ENVIRONMENT");
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false); 

            string additioonalCofigFile = $"appsettings.{env}.json";
            if (File.Exists(additioonalCofigFile))
            {
                configurationBuilder.AddJsonFile(additioonalCofigFile, false);
            }

            return configurationBuilder.Build();
        }
    }
}
