using System;
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

            UpdateTemperature(client);
            
            
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            channel.ShutdownAsync().Wait();
        }

        public static async Task UpdateTemperature(Thermometer.ThermometerClient client)
        {
            const double minValue = -10.0;
            const double maxValue = 100.0;

            while (true)
            {
                var rnd = new Random();
                var value = rnd.NextDouble() * (maxValue - minValue) + minValue;
                var temp = new Temperature((decimal)value, ThermometerLibrary.Unit.Celsius);
                client.UpdateTemperature(new UpdateTemperatureRequest{Value=(double)temp.Value, Init=Unit.Celsius });
                await Task.Delay(1000);
            }
        }
    }
}