using System;
using System.Collections.Generic;
using System.Threading;
using TemperatureLibrary;
using TemperatureLibrary.Alerters;
using TemperatureLibrary.Converter;

namespace ThermometerConsole
{
    class Program
    {
        private static IThermometer thermometer;
        static void Main(string[] args)
        {
            var converter = new TemperatureConverter(new ConverterFactory(new List<IUnitConverter>{new CelsiusConverter(),new FahrenheitConverter()}));

            var alerters = new List<IAlerter>
            {
                new DropAlert("Freezing alert", 0.0m, 0.5m,()=>Console.WriteLine("----Freezing Alert------s")),
                new RaiseAlert("Boiling alert", 100, 0.5m,()=>Console.WriteLine("----Boiling Alert----")),
                new BidirectionalAlert("Nice temperature alert", 28.0m, 1m,()=>Console.WriteLine("----I like this temperture alert-------"))
            };

            thermometer = new AlerterThermometer(Unit.Celsius,converter, alerters);



            ChangeSourceTemperature(new Temperature(15.0m,Unit.Celsius));
            Thread.Sleep(1000);
            ChangeSourceTemperature(new Temperature(32m,Unit.Fahrenheit));
            Thread.Sleep(1000);
            ChangeSourceTemperature(new Temperature(0.1m, Unit.Celsius));
            Thread.Sleep(1000);
            ChangeSourceTemperature(new Temperature(0.0m, Unit.Celsius));
            Thread.Sleep(1000);
            ChangeSourceTemperature(new Temperature(10.0m, Unit.Celsius));
            Thread.Sleep(1000);
            ChangeSourceTemperature(new Temperature(32.0m, Unit.Celsius));
            Thread.Sleep(1000);
            ChangeSourceTemperature(new Temperature(100.0m, Unit.Celsius));
            Thread.Sleep(1000);
            ChangeSourceTemperature(new Temperature(99.8m, Unit.Celsius));
            Thread.Sleep(1000);
            ChangeSourceTemperature(new Temperature(100m, Unit.Celsius));
            Thread.Sleep(1000);
            ChangeSourceTemperature(new Temperature(30m, Unit.Celsius));
            Thread.Sleep(1000);
            ChangeSourceTemperature(new Temperature(28m, Unit.Celsius));
            Thread.Sleep(1000);
            ChangeSourceTemperature(new Temperature(25m, Unit.Celsius));
            Thread.Sleep(1000);
            ChangeSourceTemperature(new Temperature(28m, Unit.Celsius));
            Thread.Sleep(1000);
            ChangeSourceTemperature(new Temperature(0m, Unit.Celsius));
        }

        

        private static void ChangeSourceTemperature(ITemperature temperature)
        {
            Console.WriteLine("new temp received {0}", temperature);
            thermometer.UpdateTemperature(temperature);
        }
    }
}