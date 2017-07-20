using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;
using ThermometerService.Pb;
using ThermometerLibrary;
using ThermometerLibrary.Alerters;
using ThermometerLibrary.Converter;

namespace ThermometerService
{
    class ThermometerImpl : Pb.Thermometer.ThermometerBase
    {
        // Server side handler 
        public override Task<TemperatureReply> GetTemperature(TemperatureRequest request, ServerCallContext context)
        {

            return Task.FromResult(new TemperatureReply { Value = (double)Program.Thermometer.Temperature.Value });
        }
    }


    class Program
    {
        const int Port = 50051;

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
                new RaiseAlert("Boiling alert", 2m, 0.5m,()=>Console.WriteLine("----Boiling Alert----")),
                new BidirectionalAlert("Exact 1 Degree", 1m, 1m,async () =>
                {
                    Console.WriteLine("---- long process to notify everyone-------");
                    await Task.Delay(3000);
                    Console.WriteLine("----end of long notification process-------");
                })
            };

            Thermometer = new AlerterThermometer(Unit.Celsius, converter, alerters);
           

            var server = new Server
            {
                Services = { Pb.Thermometer.BindService(new ThermometerImpl()) },
                Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
            };
            server.Start();
            UpdateTemperature();

            Console.WriteLine("Thermometer server listening on port " + Port);
            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();
            

            server.ShutdownAsync().Wait();
        }

        public static async Task UpdateTemperature()
        {
            const double minValue = -1.0;
            const double maxValue = 1.0;

            while (true)
            {
                var rnd = new Random();
                var value = rnd.NextDouble() * (maxValue - minValue) + minValue;
                var temp = new Temperature(Thermometer.Temperature.Value + (decimal) value, Unit.Celsius);
                Thermometer.UpdateTemperature(temp);
//                Console.WriteLine("new temp received: {0}", temp);
                await Task.Delay(1000);
            }
        }


    }
}