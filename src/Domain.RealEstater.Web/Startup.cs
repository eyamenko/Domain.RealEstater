using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.RealEstater.Contracts.Data;
using Domain.RealEstater.Contracts.Matchers;
using Domain.RealEstater.Contracts.Services;
using Domain.RealEstater.Data;
using Domain.RealEstater.Matchers;
using Domain.RealEstater.Models;
using Domain.RealEstater.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.RealEstater.Web
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(o =>
            {
                o.RespectBrowserAcceptHeader = true;
                o.InputFormatters.Add(new XmlSerializerInputFormatter());
                o.OutputFormatters.Add(new XmlSerializerOutputFormatter());
            });

            #region Services

            services.AddSingleton<IQueueService<Property>, PropertyQueueService>();
            services.AddSingleton<IPropertyService, PropertyService>();

            #endregion

            #region Data

            services.AddSingleton<IConnectionFactory>(_ =>
                new MySqlConnectionFactory(_configuration.GetConnectionString("RealEstater")));

            services.AddSingleton<IQueueRepository, QueueRepository>();
            services.AddSingleton<IPropertyRepository, PropertyRepository>();

            #endregion

            #region Property Matchers

            services.AddSingleton<IMatcherFactory, MatcherFactory>();
            services.AddSingleton<IPropertyMatcher, ContraryRealEstatePropertyMatcher>();
            services.AddSingleton<IPropertyMatcher, LocationRealEstatePropertyMatcher>();
            services.AddSingleton<IPropertyMatcher, OnlyTheBestRealEstatePropertyMatcher>();

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true,
                    ConfigFile = "webpack.dev.js"
                });
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new {controller = "Home", action = "Index"});
            });
        }
    }
}