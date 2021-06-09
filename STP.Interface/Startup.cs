using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using STP.Business.Configurations;
using STP.Interface.Configurations;
using STP.Interface.Extensions;

namespace STP.Interface
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddControllers();
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "STP.Interface", Version = "v1" });
            //});

            ApiConfig.WebApiConfig(services, Configuration);

            ConfigureBindingsDependencyInjection.RegisterBindings(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IApiVersionDescriptionProvider provider,
            IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //    app.UseSwagger();
            //    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "STP.Interface v1"));
            //}

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors("Development");
            }
            else
            {
                app.UseHsts();
                app.UseCors("Production");
            }

            //app.UseHttpMetrics();
            //app.UseMetricServer();

            app.UseAuthentication();

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseMvcConfiguration(provider, Configuration);
        }
    }
}
