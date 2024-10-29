using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorWasmServerAuth.Kernel;

public class ServiceProviderFactory : IServiceProviderFactory<IServiceProvider>
{
    public IServiceProvider CreateBuilder(IServiceCollection services)
    {
        App.ServiceProvider = services.BuildServiceProvider();
        App.Configuration = App.GetRequiredService<IConfiguration>();
        return App.ServiceProvider;
    }

    public IServiceProvider CreateServiceProvider(IServiceProvider containerBuilder)
    {
        return containerBuilder;
    }
}