using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorWasmServerAuth.Kernel;

public interface IServiceBuilder
{ 
        IServiceCollection Services { get; }

        Action<IApplicationBuilder> AppBuilder { get; set; }
 
}