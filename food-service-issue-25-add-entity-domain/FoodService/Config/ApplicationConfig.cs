using Microsoft.Extensions.Configuration;
using System.IO;

namespace Food.FoodService.Config
{
    internal class ApplicationConfig
    {
        public DbContextConfiguration dbContextConfiguration => _serviceConfiguration.GetSection("DbContextConfiguration").Get<DbContextConfiguration>();

        private readonly IConfiguration _serviceConfiguration;

        public ApplicationConfig()
        {
            _serviceConfiguration = GetServiceConfiguration();
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
