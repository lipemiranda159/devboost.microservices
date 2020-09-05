﻿using devboost.dronedelivery.felipe.DTO;
using devboost.dronedelivery.felipe.DTO.Constants;
using devboost.dronedelivery.felipe.DTO.Models;
using devboost.dronedelivery.felipe.EF.Data;
using devboost.dronedelivery.felipe.EF.Repositories;
using devboost.dronedelivery.felipe.EF.Repositories.Interfaces;
using devboost.dronedelivery.felipe.Facade;
using devboost.dronedelivery.felipe.Facade.Factory;
using devboost.dronedelivery.felipe.Facade.Interface;
using devboost.dronedelivery.felipe.Security;
using devboost.dronedelivery.felipe.Security.Extensions;
using devboost.dronedelivery.felipe.Security.Interfaces;
using devboost.dronedelivery.felipe.Services;
using devboost.dronedelivery.felipe.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Net.Http;
using System.Reflection;

namespace devboost.dronedelivery.felipe.Extensions
{
    /// <summary>
    /// Service Collection extensions
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        private const string PAYMENT_SETTINGS = "PaymentSettingsData";

        /// <summary>
        /// Add services from project
        /// </summary>
        /// <param name="services"></param>
        public static void AddScopedServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDroneRepository, DroneRepository>();
            services.AddScoped<IPedidoDroneRepository, PedidoDroneRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IPedidoService, PedidoService>();
            services.AddScoped<IDroneService, DroneService>();
            services.AddScoped<ICoordinateService, CoordinateService>();
            services.AddScoped<IPedidoFacade, PedidoFacade>();
            services.AddScoped<IDroneFacade, DroneFacade>();
            services.AddScoped<ILoginValidator, LoginValidator>();
            services.AddScoped<IValidateDatabase, ValidateDatabse>();
            services.AddScoped<ICommandExecutor<DroneStatusResult>, CommandExecutor<DroneStatusResult>>();
            services.AddScoped<ICommandExecutor<StatusDroneDto>, CommandExecutor<StatusDroneDto>>();
            services.AddScoped<IPagamentoServiceFactory, PagamentoServiceFactory>();
            services.AddScoped<IPagamentoFacade, PagamentoFacade>();
            var pagamentoSettings = configuration.GetSection(PAYMENT_SETTINGS).Get<PaymentSettings>();
            services.AddSingleton(pagamentoSettings);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddAuthServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Configurando o uso da classe de contexto para
            // acesso às tabelas do ASP.NET Identity Core
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("InMemoryDatabase"));

            // Ativando a utilização do ASP.NET Identity, a fim de
            // permitir a recuperação de seus objetos via injeção de
            // dependências
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Configurando a dependência para a classe de validação
            // de credenciais e geração de tokens
            services.AddScoped<AccessManager>();

            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

            var tokenConfigurations = new TokenConfigurations();
            new ConfigureFromConfigurationOptions<TokenConfigurations>(
                configuration.GetSection("TokenConfigurations"))
                    .Configure(tokenConfigurations);
            services.AddSingleton(tokenConfigurations);

            // Aciona a extensão que irá configurar o uso de
            // autenticação e autorização via tokens
            services.AddJwtSecurity(
                signingConfigurations, tokenConfigurations);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static void AddDbService(this IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseInMemoryDatabase("Delivery"), ServiceLifetime.Singleton);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static void AddSwagger(this IServiceCollection services)
        {

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    ProjectConsts.API_VERSION,
                    new OpenApiInfo
                    {
                        Title = ProjectConsts.PROJECT_NAME,
                        Version = ProjectConsts.API_VERSION
                    });
                var xmlFile = Assembly.GetExecutingAssembly().GetName().Name +
                    ProjectConsts.XML_EXTENSION;
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

    }
}