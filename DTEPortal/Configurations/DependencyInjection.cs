using System.Reflection;

namespace NewCoreApp.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection InstallServices(
                this IServiceCollection services,
                IConfiguration configuration,
                params Assembly[] assemblies)
        {
            IEnumerable<IServiceInstaller> serviceInstallers = assemblies.SelectMany(assembly => assembly.DefinedTypes)
                .Where(IsAssignableToType<IServiceInstaller>)
                .Select(Activator.CreateInstance)
                .Cast<IServiceInstaller>();

            foreach (IServiceInstaller installer in serviceInstallers)
            {
                installer.Install(services, configuration);
            }

            return services;

        }
        static bool IsAssignableToType<T>(TypeInfo typeInfo) =>
                typeof(T).IsAssignableFrom(typeInfo)
                    && !typeInfo.IsInterface
                    && !typeInfo.IsAbstract;
    }
}
