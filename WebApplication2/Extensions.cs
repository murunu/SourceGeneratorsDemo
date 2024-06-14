using System.Reflection;

namespace WebApplication2;

public static class Extensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        var types = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(x => x.GetCustomAttributes<RegisterAttribute>()
                .Any());

        foreach (var type in types)
        {
            var constructorArguments = type.CustomAttributes.First().ConstructorArguments;
            if (constructorArguments.Count < 2)
            {
                var lifetimeInternal = (ServiceLifetime) constructorArguments[0].Value;

                _ = lifetimeInternal switch
                {
                    ServiceLifetime.Transient => services.AddTransient(type),
                    ServiceLifetime.Scoped => services.AddScoped(type),
                    ServiceLifetime.Singleton => services.AddSingleton(type),
                    _ => throw new ArgumentOutOfRangeException()
                };    
                
                continue;
            }
            
            var lifetime = (ServiceLifetime) constructorArguments[0].Value;
            var interfaceType = (Type) constructorArguments[1].Value;
            
            _ = lifetime switch
            {
                ServiceLifetime.Transient => services.AddTransient(interfaceType, type),
                ServiceLifetime.Scoped => services.AddScoped(interfaceType, type),
                ServiceLifetime.Singleton => services.AddSingleton(interfaceType, type),
                _ => throw new ArgumentOutOfRangeException()
            };    
        }
        
        return services;
    }
}