using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;
using ThermometerService.Pb;
using ThermometerLibrary;
using ThermometerLibrary.Alerters;
using ThermometerLibrary.Converter;
using Unit = ThermometerLibrary.Unit;

namespace ThermometerService;

internal class ThermometerImpl : Pb.Thermometer.ThermometerBase
{
    // Server side handler 
    public override Task<TemperatureReply> GetTemperature(TemperatureRequest request, ServerCallContext context)
    {
        return Task.FromResult(new TemperatureReply { Value = (double)Program.Thermometer.Temperature.Value, Unit = Pb.Unit.Celsius});
    }

    public override Task<UpdateTemperatureReply> UpdateTemperature(UpdateTemperatureRequest request, ServerCallContext context)
    {
        var temp = new Temperature((decimal)request.Value,Unit.Celsius);
        Console.WriteLine("New Temp received: {0}", temp);
        Program.Thermometer.UpdateTemperature(temp);
        return Task.FromResult(new UpdateTemperatureReply());
    }
}

internal static class Program
{
    private const int Port = 50051;

    public static IThermometer Thermometer;

    public static void Main(string[] args)
    {
        var converter = new TemperatureConverter(new ConverterFactory(
            new List<IUnitConverter>
            {
                new CelsiusConverter(),
                new FahrenheitConverter()
            }));

        var alerters = new List<IAlerter>
        {
            new DropAlert("Freezing alert", 0.0m, 0.5m,()=>Console.WriteLine("----Freezing Alert------s")),
            new RaiseAlert("Boiling alert", 100m, 0.5m,()=>Console.WriteLine("----Boiling Alert----")),
            new BidirectionalAlert("28 Degree", 28m, 1m,async () =>
            {
                Console.WriteLine("---- long process to notify everyone-------");
                await Task.Delay(3000);
                Console.WriteLine("----end of long notification process-------");
            })
        };

        Thermometer = new AlerterThermometer(ThermometerLibrary.Unit.Celsius, converter, alerters);
           

        var server = new Server
        {
            Services = { Pb.Thermometer.BindService(new ThermometerImpl()) },
            Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
        };
        server.Start();

        Console.WriteLine("Thermometer server listening on port " + Port);
        Console.WriteLine("Press any key to stop the server...");
        Console.ReadKey();
            

        server.ShutdownAsync().Wait();
    }
}