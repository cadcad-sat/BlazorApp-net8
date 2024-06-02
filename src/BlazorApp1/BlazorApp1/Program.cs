using BlazorApp1.Components;
using MyGrpcService;
using ProtoBuf.Grpc.Server;

var builder = WebApplication.CreateBuilder(args);

// gRPC サービスを追加
builder.Services.AddCodeFirstGrpc();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddTransient<IGreetingService, GreetingService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

// gRPC のサービスの追加
app.UseGrpcWeb();
app.MapGrpcService<GreetingService>().EnableGrpcWeb();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorApp1.Client._Imports).Assembly);

app.Run();
