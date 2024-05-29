using ProtoBuf.Grpc;

namespace MyGrpcService;

public class GreetingService : IGreetingService
{
    public Task<HelloReply> SayHello(HelloRequest request, CallContext context = default)
    {
        return Task.FromResult(new HelloReply { Message = $"Hello, {request.Name}!" });
    }
}

