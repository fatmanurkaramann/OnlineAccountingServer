﻿using System.Reflection;

namespace OnlineAccountingServer.WebApi.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection InstallService(this IServiceCollection services,
            IConfiguration configuration,params Assembly[] assemblies)
        {
            IEnumerable<IServiceInstaller> serviceInstallers=assemblies
                .SelectMany(a=>a.DefinedTypes)
                .Where(IsAssignableToType<IServiceInstaller>)
                .Select(Activator.CreateInstance)
                .Cast<IServiceInstaller>();

            foreach (IServiceInstaller service in serviceInstallers)
            {
                service.Install(services, configuration);
            }
            return services;

                static bool IsAssignableToType<T>(TypeInfo typeInfo)=>
                  typeof(T).IsAssignableFrom(typeInfo) &&
                  !typeInfo.IsInterface && !typeInfo.IsAbstract;
        }
    }
}
