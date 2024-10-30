using BlazorWasmServerAuth.Kernel;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BlazorWasmServerAuth.Client;


public static class ServiceCollectionExtensions
{

     


    public static IServiceCollection AddBlazorWasmServerAuthClient(this IServiceCollection services)
    {
        var connectionString = App.Configuration.GetConnectionString("main");
        
       //添加数据库访问
        services.AddSingleton<IFreeSql<DbMainFlag>>(provider =>
        { 
            var freeSql = new FreeSql.FreeSqlBuilder() 
                .UseConnectionString(FreeSql.DataType.SqlServer, connectionString)
                .UseMonitorCommand(cmd => Console.WriteLine($@"Sql：CommandText=>{cmd.CommandText}\r\nParameters=>{cmd.Parameters}"))
                .UseAutoSyncStructure(true) //自动同步实体结构到数据库，只有CRUD时才会生成表
                .Build<DbMainFlag>();
            
            return freeSql; 
        });
        
        
        //添加权限认证服务
        services.AddScoped<MyAuthenticationStateProvider>();
        services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<MyAuthenticationStateProvider>());
        services.AddAuthorizationCore();
        
        return services;
    }
}
