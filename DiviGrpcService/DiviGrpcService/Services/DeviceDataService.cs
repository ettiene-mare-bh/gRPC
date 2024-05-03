using Grpc.Core;
using Google.Protobuf;

namespace DiviGrpcService.Services;

public class DeviceDataService : DataService.DataServiceBase
{
    private readonly ILogger<GreeterService> _logger;

    public DeviceDataService(ILogger<GreeterService> logger)
    {
        _logger = logger;
    }

    public override Task<DataReply> GetData(DataRequest request, ServerCallContext context) => GetData();

    public Task<DataReply> GetData()
    {
        var dataJson = File.ReadAllText("Data\\NodeId_8-FileId.json");
        
        var message = Activator.CreateInstance(typeof(DataReply)) as IMessage;
        var result = (DataReply)JsonParser.Default.Parse(dataJson, message?.Descriptor);
        return Task.FromResult(result);
    }
}