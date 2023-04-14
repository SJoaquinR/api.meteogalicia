using MeteoGalicia.Data;
using MeteoGalicia.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

[assembly: ApiConventionType(typeof(DefaultApiConventions))]
namespace MeteoGalicia
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices (IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(sw =>
            {
                sw.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "MeteoGalicia"
                    ,
                    Version = "v1"
                    ,
                    Description = "Web API - Meteorologia de Galicia",
                    Contact = new OpenApiContact
                    {
                        Name = "SJR"
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT-SJR"
                    }
                });
            });

            services.AddSingleton(new MunicipalityDAL(new MunicipalityBLL(Configuration)));
            

            services.AddAutoMapper(typeof(Startup));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
