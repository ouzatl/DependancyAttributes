using DependancyAttributes.Attributes;

namespace DependancyAttributes.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddProjectDependancies(this IServiceCollection services)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            var injectableServices = assemblies
                    .SelectMany(a => a.GetTypes().Where(t =>
                     t.IsDefined(typeof(SingletonServiceAttribute), false)
                     || t.IsDefined(typeof(ScopedServiceAttribute), false)
                     || t.IsDefined(typeof(TransientServiceAttribute), false)
                     ));

            if (injectableServices != null && injectableServices.Any())
            {
                foreach (var injectableService in injectableServices)
                {
                    var singletonInfo = injectableService.GetCustomAttributes(typeof(SingletonServiceAttribute), true).FirstOrDefault() as SingletonServiceAttribute;
                    var scopedInfo = injectableService.GetCustomAttributes(typeof(ScopedServiceAttribute), true).FirstOrDefault() as ScopedServiceAttribute;
                    var transientInfo = injectableService.GetCustomAttributes(typeof(TransientServiceAttribute), true).FirstOrDefault() as TransientServiceAttribute;

                    if (singletonInfo != null)
                    {
                        if (singletonInfo.TypeOfImplementation != null && singletonInfo.TypeOfService != null)
                        {
                            services.AddSingleton(singletonInfo.TypeOfService, singletonInfo.TypeOfImplementation);
                        }
                        else if (singletonInfo.TypeOfImplementation != null)
                        {
                            services.AddSingleton(singletonInfo.TypeOfImplementation);
                        }
                    }
                    else if (scopedInfo != null)
                    {
                        if (scopedInfo.TypeOfImplementation != null && scopedInfo.TypeOfService != null)
                        {
                            services.AddScoped(scopedInfo.TypeOfService, scopedInfo.TypeOfImplementation);
                        }
                        else if (scopedInfo.TypeOfImplementation != null)
                        {
                            services.AddScoped(scopedInfo.TypeOfImplementation);
                        }
                    }
                    else if (transientInfo != null)
                    {
                        if (transientInfo.TypeOfImplementation != null && transientInfo.TypeOfService != null)
                        {
                            services.AddTransient(transientInfo.TypeOfService, transientInfo.TypeOfImplementation);
                        }
                        else if (transientInfo.TypeOfImplementation != null)
                        {
                            services.AddTransient(transientInfo.TypeOfImplementation);
                        }
                    }
                }
            }
        }
    }
}
