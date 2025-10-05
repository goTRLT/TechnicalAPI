using Application.Interfaces;
using Application.Services;
using AutoMapper;
using Domain.Interfaces;
using Infrastructure.Context;
using Infrastructure.Mappings;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Api
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services, string connectionString)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services
                .AddEntityFrameworkNpgsql()
                .AddDbContext<TechDbContext>(options => options
                .UseNpgsql(connectionString));

            services.AddScoped<IBancoService, BancoService>();
            services.AddScoped<IBoletoService, BoletoService>();
            services.AddScoped<IBancoRepository, BancoRepository>();
            services.AddScoped<IBoletoRepository, BoletoRepository>();

            services.AddAutoMapper(map => map.AddProfile(new MapProfile()));
        }
    }
}
