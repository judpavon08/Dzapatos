using Domain.Endpoint.Interfaces.Services;
using Domain.Endpoint.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;

namespace WebApi.Providers
{
    public class DefaultDependencyResolver : IDependencyResolver
    {
        protected IServiceProvider serviceProvider;

        public DefaultDependencyResolver(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IDependencyScope BeginScope()
        {
            return new DefaultDependencyResolver(serviceProvider.CreateScope().ServiceProvider);
        }

        public void Dispose() { }

        public object GetService(Type serviceType)
        {
            return serviceProvider.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return serviceProvider.GetServices(serviceType);
        }
    }

    public static class ServiceProviderExtensions
    {
        //public static IServiceCollection AddControllersAsServices(this IServiceCollection services, IEnumerable<Type> controllerTypes)
        //{
        //    foreach (Type type in controllerTypes)
        //    {
        //        services.AddTransient(type);
        //    }

        //    return services;
        //}

        public static IServiceCollection AddControllersAsServices(this IServiceCollection services, IEnumerable<Type> controllerTypes)
        {
            foreach (Type type in controllerTypes)
            {
                services.AddTransient(type);
            }

            // Agrega la registración de tus servicios personalizados
            services.AddScoped<ITallasService, TallasService>(); // Reemplaza TallasService con la implementación real de ITallasService
            services.AddScoped<IMarcaService, MarcaService>(); // Reemplaza TallasService con la implementación real de ITallasService

            return services;
        }

    }
}