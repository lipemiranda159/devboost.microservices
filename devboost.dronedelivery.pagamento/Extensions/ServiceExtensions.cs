using devboost.dronedelivery.felipe.DTO.Models;
using devboost.dronedelivery.pagamento.EF;
using devboost.dronedelivery.pagamento.EF.Repositories;
using devboost.dronedelivery.pagamento.EF.Repositories.Interfaces;
using devboost.dronedelivery.pagamento.facade;
using devboost.dronedelivery.pagamento.facade.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace devboost.dronedelivery.pagamento.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPagamentoFacade, PagamentoFacade>();
            services.AddScoped<IPagamentoRepository, PagamentoRepository>();

        }
        public static void ConfigureCors(this IServiceCollection services) =>
          services.AddCors(options =>
          {
              options.AddPolicy("CorsPolicy", builder =>
                  builder.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader());
          });

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
           services.AddDbContext<DataContext>(opts =>
               opts.UseInMemoryDatabase("pagamentos-db"));

        public static void ConfigureVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(opt =>
            {
                opt.ReportApiVersions = true;
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.DefaultApiVersion = new ApiVersion(1, 0);
                opt.ApiVersionReader = new HeaderApiVersionReader("api-version");
                opt.Conventions.Controller<Pagamento>().HasApiVersion(new ApiVersion(1, 0));
            });
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            OpenApiSecurityScheme openApiSecurityScheme = new OpenApiSecurityScheme();

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Dev-Boost-Pagamentos API",
                    Version = "v1",
                    Description = "Grupo 4: Autores: Felipe Miranda, Italo Vinicios, Lucas Scheid e Marco Antonio.",
                });

            });
        }
    }
}
