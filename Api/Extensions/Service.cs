using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Infrastructure.Context;
using Infrastructure.Mappings;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Api.Extensions
{
    public static class Service
    {
        public static void AddServices(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("TechDb");

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                // Add XML comments
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                if (File.Exists(xmlPath))
                {
                    options.IncludeXmlComments(xmlPath);
                }

                // Add metadata
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "TechnicalAPI",
                    Version = "v0.6",
                    Description = "API for Banco and Boleto management.",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Thuan Rael Lombardi",
                        Email = "thuanraellombardi@gmail.com"
                    }
                });
            });

            builder.Services
              .AddDbContext<TechDbContext>(options => options
              .UseNpgsql(connectionString, b => b
              .MigrationsAssembly("Infrastructure")));

            builder.Services.AddScoped<IBancoService, BancoService>();
            builder.Services.AddScoped<IBoletoService, BoletoService>();
            builder.Services.AddScoped<IBancoRepository, BancoRepository>();
            builder.Services.AddScoped<IBoletoRepository, BoletoRepository>();

            builder.Services.AddAutoMapper(map => map.AddProfile(new MapProfile()));
        }
    }
}
