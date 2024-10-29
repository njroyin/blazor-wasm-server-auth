using BlazorWasmServerAuth.Client;
using BlazorWasmServerAuth.Kernel;
using Microsoft.AspNetCore.Components.Authorization;
using App = BlazorWasmServerAuth.Components.App;

var builder = WebApplication.CreateBuilder(args);

builder.Host.AddKernel(); 
  
builder.Services.AddKernel();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

 
builder.Services.AddBootstrapBlazor();


//添加权限认证服务
builder.Services.AddScoped<MyAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<MyAuthenticationStateProvider>());
builder.Services.AddAuthorizationCore();
 

//添加BlazorWasmServerAuth.Client初始化服务
//builder.Services.AddBlazorWasnServerRestfulAPIClient(builder.Configuration);
builder.Services.AddBlazorWasnServerRestfulAPIClient();


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
