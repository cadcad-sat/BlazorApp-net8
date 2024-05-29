using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyGrpcService;
using ProtoBuf.Grpc.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// クライアントを追加
builder.Services.AddSingleton(sp =>
{
    var httpHandler = new GrpcWebHandler(GrpcWebMode.GrpcWeb, new HttpClientHandler());
    return GrpcChannel.ForAddress(
        builder.HostEnvironment.BaseAddress,
        new GrpcChannelOptions
        {
            HttpHandler = httpHandler,
        });
});
builder.Services.AddTransient<IGreetingService>(sp =>
{
    var channel = sp.GetRequiredService<GrpcChannel>();
    return channel.CreateGrpcService<IGreetingService>();
});

await builder.Build().RunAsync();
