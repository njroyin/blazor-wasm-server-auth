using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BlazorWasmServerAuth.Kernel;
 
public class ServiceBuilder : IServiceBuilder
{
    public IServiceCollection Services { get; }

    public Action<IApplicationBuilder> AppBuilder { get; set; }

    public ServiceBuilder(IServiceCollection services)
    {
        Services = services;
        
        //Services.AddSingleton<IMemoryCache, MemoryCache>();
        // GlobalInjection.Injection(Services);
        App.ServiceProvider = Services.BuildServiceProvider();
        App.Configuration = App.GetRequiredService<IConfiguration>();
         
    }
}