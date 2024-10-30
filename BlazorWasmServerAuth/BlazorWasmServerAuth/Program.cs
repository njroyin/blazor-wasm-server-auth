using BlazorWasmServerAuth.Client;
using BlazorWasmServerAuth.Kernel;
using Microsoft.AspNetCore.Components.Authorization;
using App = BlazorWasmServerAuth.Components.App;

var builder = WebApplication.CreateBuilder(args);

//添加Kernel核心服务
builder.Host.AddKernel(); 

//注册Kernel核心服务
builder.Services.AddKernel();
//注册BlazorWasmServerAuth.Client客户端服务
builder.Services.AddBlazorWasmServerAuthClient();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

 
builder.Services.AddBootstrapBlazor();
  
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorWasmServerAuth.Client._Imports).Assembly);
 

app.Run();
