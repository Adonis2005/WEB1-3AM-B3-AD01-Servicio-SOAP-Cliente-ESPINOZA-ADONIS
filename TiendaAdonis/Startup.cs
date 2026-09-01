using TiendaAdonis.Data;
using TiendaAdonis.Services;

using CoreWCF;
using CoreWCF.Configuration;
using CoreWCF.Description;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TiendaAdonis
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            // Conexión con SQL Server
            services.AddDbContext<TiendaCocinaDBContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("TiendaConnection")
                )
            );

            // Registrar los servicios
            services.AddScoped<ProductoService>();
            services.AddScoped<CategoriaService>();

            // Configuración de CoreWCF
            services.AddServiceModelServices()
                    .AddServiceModelMetadata();

            services.AddSingleton<IServiceBehavior,
                UseRequestHeadersForMetadataAddressBehavior>();
        }


        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseServiceModel(serviceBuilder =>
            {
                // Servicio de Productos
                serviceBuilder
                    .AddService<ProductoService>()
                    .AddServiceEndpoint<ProductoService, IProductoService>(
                        new BasicHttpBinding(),
                        "/ProductoService.svc"
                    );


                // Servicio de Categorías
                serviceBuilder
                    .AddService<CategoriaService>()
                    .AddServiceEndpoint<CategoriaService, ICategoriaService>(
                        new BasicHttpBinding(),
                        "/CategoriaService.svc"
                    );
            });


            // Habilitar metadata / WSDL
            var metadataBehavior =
                app.ApplicationServices
                   .GetRequiredService<ServiceMetadataBehavior>();

            metadataBehavior.HttpGetEnabled = true;
        }
    }
}