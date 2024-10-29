using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorWasmServerAuth.Kernel;

public class App
{
    public static IServiceProvider ServiceProvider { get; set; }
    public static IConfiguration Configuration { get; set; }
    
    public static object GetService(Type serviceType)
    {
        return ServiceProvider.GetService(serviceType);
    }

    public static T GetService<T>()
    {
        return ServiceProvider.GetService<T>();
    }

    public static IEnumerable<T> GetServices<T>()
    {
        return ServiceProvider.GetServices<T>();
    }

    public static object GetRequiredService(Type serviceType)
    {
        return ServiceProvider.GetRequiredService(serviceType);
    }

    public static T GetRequiredService<T>()
    {
        return ServiceProvider.GetRequiredService<T>();
    }

    public static IEnumerable<object> GetServices(Type serviceType)
    {
        return ServiceProvider.GetServices(serviceType);
    }

    public static T GetConfig<T>(string key = "")
    {
        if (string.IsNullOrWhiteSpace(key))
        {
            key = typeof(T).Name.Replace("config", string.Empty, StringComparison.OrdinalIgnoreCase);
        }

        return Configuration.GetSection(key).Get<T>();
    }
}