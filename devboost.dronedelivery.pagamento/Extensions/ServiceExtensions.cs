using devboost.dronedelivery.pagamento.Models;
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

        //services.AddDbContext<DataContext>(options =>
        //            options.UseInMemoryDatabase("base"), ServiceLifetime.Singleton);



        //public static void ConfigureRepositoryManager(this IServiceCollection services) =>
        //  services.AddScoped<IRepositoryManager, RepositoryManager>();

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

        //public static void ConfigureIdentity(this IServiceCollection services)
        //{
        //    var builder = services.AddIdentityCore<User>(o =>
        //    {
        //        o.Password.RequireDigit = true;
        //        o.Password.RequireLowercase = false;
        //        o.Password.RequireUppercase = false;
        //        o.Password.RequireNonAlphanumeric = false;
        //        o.Password.RequiredLength = 10;
        //        o.User.RequireUniqueEmail = true;
        //    });

        //    builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), builder.Services);
        //    builder.AddEntityFrameworkStores<RepositoryContext>()
        //        .AddDefaultTokenProviders();
        //}

        //public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        //{
        //    var jwtSettings = configuration.GetSection("JwtSettings");
        //    var secretKey = Environment.GetEnvironmentVariable("SECRET");

        //    services.AddAuthentication(opt =>
        //    {
        //        opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //        opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //    })
        //    .AddJwtBearer(options =>
        //    {
        //        options.TokenValidationParameters = new TokenValidationParameters
        //        {
        //            ValidateIssuer = true,
        //            ValidateAudience = true,
        //            ValidateLifetime = true,
        //            ValidateIssuerSigningKey = true,

        //            ValidIssuer = jwtSettings.GetSection("validIssuer").Value,
        //            ValidAudience = jwtSettings.GetSection("validAudience").Value,
        //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
        //        };
        //    });
        //}

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

                //add JWT Authentication
                //var securityScheme = new OpenApiSecurityScheme
                //{
                //    Name = "JWT Authentication",
                //    Description = "Enter JWT Bearer token **_only_**",
                //    In = ParameterLocation.Header,
                //    Type = SecuritySchemeType.Http,
                //    Scheme = "bearer", // must be lower case
                //    BearerFormat = "JWT",
                //    Reference = new OpenApiReference
                //    {
                //        Id = JwtBearerDefaults.AuthenticationScheme,
                //        Type = ReferenceType.SecurityScheme
                //    }
                //};

                //s.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);

                //s.AddSecurityRequirement(new OpenApiSecurityRequirement
                //{
                //    {securityScheme, new string[] { }}
                //});
            });
        }
    }
}
