using BlazorWasmServerAuth.Kernel;

namespace BlazorWasmServerAuth.Client;

public static class Program
{
    public static IServiceCollection AddBlazorWasnServerRestfulAPIClient(this IServiceCollection services)
    {
        var connectionString = App.Configuration.GetConnectionString("main");
        
       //添加数据库访问
        services.AddSingleton<IFreeSql>(provider =>
        { 
            IFreeSql fsql = new FreeSql.FreeSqlBuilder()
                .UseConnectionString(FreeSql.DataType.SqlServer, connectionString)
                .UseMonitorCommand(cmd => Console.WriteLine($@"Sql：CommandText=>{cmd.CommandText}\r\nParameters=>{cmd.Parameters}"))
                .UseAutoSyncStructure(true) //自动同步实体结构到数据库，只有CRUD时才会生成表
                .Build();
            return fsql; 
        });
        
        return services;
    }
}
