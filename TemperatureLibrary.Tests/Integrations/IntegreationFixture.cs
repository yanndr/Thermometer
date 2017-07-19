using System;
using System.Collections.Generic;
using TemperatureLibrary.Alerters;
using TemperatureLibrary.Converter;
using Xunit;

namespace TemperatureLibrary.Tests.Integrations
{
    public class IntegreationFixture
    {
        
        public IntegreationFixture()
        {
            var converter = new TemperatureConverter(new ConverterFactory(new List<IUnitConverter> { new CelsiusConverter(), new FahrenheitConverter() }));

            var alerters = new List<IAlerter>
            {
                new DropAlert("Freezing alert", 0.0m, 0.5m,()=>Console.WriteLine("----Frezing Alert")),
                new RaiseAlert("Boiling alert", 100, 0.5m,()=>Console.WriteLine("----Boiling Alert----")),
                new BidirectionalAlert("Nice temperature alert", 28.0m, 1m,()=>Console.WriteLine("----I like this temperture a;ere-------"))
            };

            var thermometer = new AlerterThermometer(Unit.Celsius, converter, alerters);

           
            

        }
    }
}
