using Domain.RealEstater.Contracts.Data;
using Domain.RealEstater.Contracts.Matchers;
using Domain.RealEstater.Contracts.Services;
using Domain.RealEstater.Data;
using Domain.RealEstater.Matchers;
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
            services.AddSingleton<IPropertyService, PropertyService>();

            #endregion

            #region Data

            services.AddSingleton<IConnectionFactory>(_ =>
                new MySqlConnectionFactory(_configuration.GetConnectionString("RealEstater")));

            services.AddSingleton<IQueueRepository, QueueRepository>();

            #endregion

            #region Property Matchers

            services.AddSingleton<IMatcherFactory, MatcherFactory>();
            services.AddSingleton<IPropertyMatcher, ContraryRealEstatePropertyMatcher>();
            services.AddSingleton<IPropertyMatcher, LocationRealEstatePropertyMatcher>();
            services.AddSingleton<IPropertyMatcher, OnlyTheBestRealEstatePropertyMatcher>();

            #endregion
        }
    }
}