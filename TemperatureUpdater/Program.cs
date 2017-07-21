using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using ThermometerLibrary;
using ThermometerService.Pb;
using Thermometer = ThermometerService.Pb.Thermometer;
using Unit = ThermometerService.Pb.Unit;

namespace TemperatureUpdater
{
    class Program
    {
        static void Main(string[] args)
        {
            var channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);

            var client = new Thermometer.ThermometerClient(channel);

            var cancel = false;
            var task = Task.Factory.StartNew(() =>
            {
                const double minValue = -10.0;
                const double maxValue = 110.0;

                while (!cancel)
                {
                    var rnd = new Random();
                    var value = rnd.NextDouble() * (maxValue - minValue) + minValue;
                    var temp = new Temperature((decimal) value, ThermometerLibrary.Unit.Celsius);
                    client.UpdateTemperature(
                        new UpdateTemperatureRequest {Value = (double) temp.Value, Init = Unit.Celsius});
                    Thread.Sleep(1000);
                }
            });
            
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            cancel = true;
            task.Wait();

            channel.ShutdownAsync().Wait();
        }

    }
}