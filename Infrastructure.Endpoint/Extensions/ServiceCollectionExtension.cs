using Domain.Endpoint.Interfaces.Repositories;
using Infrastructure.Endpoint.Data;
using Infrastructure.Endpoint.Data.Builders;
using Infrastructure.Endpoint.Data.Interfaces;
using Infrastructure.Endpoint.Data.Repositories;
using Infrastructure.Endpoint.Data.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Endpoint.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            //services.AddScoped<IToDosRepository, ToDosRepository>();
            services.AddScoped<ITallasRepository, TallasRepository>();
            services.AddScoped<IMarcaRepository, MarcaRepository>(); // repo de marca
            services.AddTransient<ISqlEntitySettingsBuilder, SqlEntitySettingsBuilder>();
            services.AddTransient<ISqlCommandOperationBuilder, SqlCommandOperationBuilder>();
            services.AddSingleton<IEntitiesService, EntitiesService>();
            services.AddSingleton<ISqlDbConnection>(SqlDbConnection.GetInstance());
            return services;
        }
    }
}
