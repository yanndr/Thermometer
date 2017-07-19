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
        public static event EventHandler<TemperatureChangedEventArgs> temperatureChanged;

        static void Main(string[] args)
        {
            var converter = new TemperatureConverter(new ConverterFactory(new List<IUnitConverter>{new CelsiusConverter(),new FahrenheitConverter()}));

            var alerters = new List<IAlerter>
            {
                new DropAlert("Freezing alert", 0.0m, 0.5m,()=>Console.WriteLine("----Frezing Alert------s")),
                new RaiseAlert("Boiling alert", 100, 0.5m,()=>Console.WriteLine("----Boiling Alert----")),
                new BidirectionalAlert("Nice temperature alert", 28.0m, 1m,()=>Console.WriteLine("----I like this temperture alert-------"))
            };

            var thermometer = new AlerterThermometer(Unit.Celsius,converter, alerters);

            temperatureChanged += thermometer.HandleTemperatureChanged;


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
            ChangeSourceTemperature(new Temperature(32.0m, Unit.Fahrenheit));
        }

        

        private static void ChangeSourceTemperature(ITemperature temperature)
        {
            Console.WriteLine("new temp received {0}", temperature);
            temperatureChanged?.Invoke(null, new TemperatureChangedEventArgs(temperature));
        }
    }
}