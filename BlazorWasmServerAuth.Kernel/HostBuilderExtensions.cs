using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace BlazorWasmServerAuth.Kernel;

public static class HostBuilderExtensions
{
    public static IHostBuilder AddKernel(this IHostBuilder hostBuilder, Action<IConfigurationBuilder> action = null)
    { 
        return hostBuilder.ConfigureAppConfiguration((hostingContext, config) =>
        {
            action?.Invoke(config);
        }).UseServiceProviderFactory(new ServiceProviderFactory());
    }
}