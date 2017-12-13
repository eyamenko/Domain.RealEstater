using Domain.RealEstater.Contracts.Data;
using Domain.RealEstater.Contracts.Services;
using Domain.RealEstater.Data;
using Domain.RealEstater.Models;
using Domain.RealEstater.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceNetCore.Contracts;

namespace Domain.RealEstater.Service
{
    public class Startup : IStartup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            #region Services

            services.AddSingleton<IQueueService<Property>, PropertyQueueService>();

            #endregion

            #region Data

            services.AddSingleton<IConnectionFactory>(_ =>
                new MySqlConnectionFactory(_configuration.GetConnectionString("RealEstater")));

            services.AddSingleton<IQueueRepository, QueueRepository>();

            #endregion
        }
    }
}