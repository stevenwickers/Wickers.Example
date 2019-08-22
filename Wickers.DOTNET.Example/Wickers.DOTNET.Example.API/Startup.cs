using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using System;
using Wickers.DOTNET.Example.API.Models;
using Wickers.DOTNET.Example.Business.Services;
using Wickers.DOTNET.Example.Business.Services.Interfaces;

namespace Wickers.DOTNET.Example.API
{
    public class Startup
    {
        private bool _isDevelopment = true;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSingleton<IConfiguration>(Configuration);

            var appSettings = (ApplicationSettingsModel)Configuration.GetSection("ApplicationSettings").Get<ApplicationSettingsModel>();
            var swaggerSettings = (SwaggerSettingsModel)Configuration.GetSection("SwaggerSettings").Get<SwaggerSettingsModel>();
            
            //Check Environment
            _isDevelopment = appSettings.Environment.Equals("Development", StringComparison.CurrentCultureIgnoreCase);

            //Services
            services.AddSingleton<IExampleServices, ExampleServices>();

            //Logging
            services.AddLogging(configureLog => configureLog
                .AddDebug()
                .AddConsole()
                .AddEventSourceLogger());

            //Sql Services
            services.AddSingleton<ISQLServices>(new SQLServices(
                appSettings.SqlConnectionString,
                appSettings.SqlTimeout));

            //Only display swagger for development
            if (_isDevelopment)
            {
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("document", new Info
                    {
                        Title = swaggerSettings.Title,
                        Description = swaggerSettings.Description,
                        Version = swaggerSettings.Version
                    });
                });
            }

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //Only display swagger for development
            if (_isDevelopment)
            {
                app.UseSwagger(c =>
                {
                    c.PreSerializeFilters.Add(
                        (swaggerDoc, httpReq) =>
                            swaggerDoc.Host = httpReq.Host.Value);
                });

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/document/swagger.json", "Wickers-Example-API");
                });
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
        
    }
}
