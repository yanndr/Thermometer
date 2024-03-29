﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ThermometerLibrary;
using ThermometerLibrary.Alerters;
using ThermometerLibrary.Converter;

namespace ThermometerConsole;

internal static class Program
{
    private static IThermometer _thermometer;

    private static void Main()
    {
        var converter = new TemperatureConverter(new ConverterFactory(
            new List<IUnitConverter>
            {
                new CelsiusConverter(),
                new FahrenheitConverter()
            }));

        var alerters = new List<IAlerter>
        {
            new DropAlert("Freezing alert", 0.0m, 0.5m, () => Console.WriteLine("----Freezing Alert------s")),
            new RaiseAlert("Boiling alert", 100, 0.5m, () => Console.WriteLine("----Boiling Alert----")),
            new BidirectionalAlert("Nice temperature alert", 28.0m, 1m, async () =>
            {
                Console.WriteLine("----Really nice temperature starting a long process to notify everyone-------");
                await Task.Delay(3000);
                Console.WriteLine("----end of the really nice notification process-------");
            })
        };

        _thermometer = new AlerterThermometer(Unit.Celsius, converter, alerters);


        for (var i = 0; i < 2; i++)
        {
            foreach (var temperature in Temperatures)
            {
                Console.Write("new temp received {0}", temperature);
                try
                {
                    _thermometer.UpdateTemperature(temperature);
                    Console.WriteLine(" -- >temp in Thermometer {0}", _thermometer.Temperature);
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine(ex.Message);
                }

                Thread.Sleep(1000);
            }
        }
    }

    private static readonly List<ITemperature> Temperatures =
        new List<ITemperature>
        {
            new Temperature(15.0m, Unit.Kelvin),
            new Temperature(12.0m, Unit.Celsius),
            new Temperature(32.0m, Unit.Fahrenheit),
            new Temperature(0.1m, Unit.Celsius),
            new Temperature(0.0m, Unit.Celsius),
            new Temperature(23.0m, Unit.Celsius),
            new Temperature(27.9m, Unit.Celsius),
            new Temperature(28.0m, Unit.Celsius),
            new Temperature(28.3m, Unit.Celsius),
            new Temperature(28.0m, Unit.Celsius),
            new Temperature(35.0m, Unit.Celsius),
            new Temperature(28.0m, Unit.Celsius),
            new Temperature(70.0m, Unit.Celsius),
            new Temperature(100.0m, Unit.Celsius),
            new Temperature(110.0m, Unit.Celsius),
            new Temperature(10.0m, Unit.Celsius),
            new Temperature(35.0m, Unit.Kelvin),
            new Temperature(28.0m, Unit.Kelvin),
            new Temperature(70.0m, Unit.Kelvin),
            new Temperature(100.0m, Unit.Fahrenheit),
            new Temperature(110.0m, Unit.Fahrenheit),
        };
}