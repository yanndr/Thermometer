using System;
using Grpc.Core;
using ThermometerService.Pb;

namespace ThermometerClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Channel channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);

            var client = new Thermometer.ThermometerClient(channel);
            String user = "you";

            var reply = client.GetTemperature(new TemperatureRequest());
            Console.WriteLine("Value: " + reply.Value);

            channel.ShutdownAsync().Wait();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}