using System.Runtime.Serialization;
using System.ServiceModel;
using ProtoBuf.Grpc;

namespace MyGrpcService;

[DataContract]
public class HelloReply
{
    [DataMember(Order = 1)]
    public required string Message { get; set; }
}

[DataContract]
public class HelloRequest
{
    [DataMember(Order = 1)]
    public required string Name { get; set; }
}

[ServiceContract]
public interface IGreetingService
{
    [OperationContract]
    Task<HelloReply> SayHello(HelloRequest request, CallContext context = default);
}