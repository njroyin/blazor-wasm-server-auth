using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorWasmServerAuth.Kernel;

public static class ServiceCollectionExtensions
{
    private static ServiceBuilder builder;

    public static IServiceBuilder AddKernel(this IServiceCollection services)
    { 
        builder = new ServiceBuilder(services);
        return builder;
    }

    internal class StartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return x =>
            {
                builder.AppBuilder(x);
                next(x);
            };
        }
    }
}