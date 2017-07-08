using System;
using System.Collections.Generic;
using Xunit;
using TemperatureLibrary;
using TemperatureLibrary.Converter;

namespace TemperatureLibrary.Tests
{
    public class TemperatureConverterFixture
    {
        [Theory]
        [InlineData(0,273.15)]
        [InlineData(60,333.15)]
        [InlineData(25,298.15)]
        public void CelsuisToKelvin(decimal input, decimal expectedResult)
        {
            var converters = new List<IUnitConverter>();
            converters.Add(new KelvinConverter()); 
            converters.Add(new FahrenheitConverter()); 
            converters.Add(new CelsiusConverter());

            var tc = new TemperatureConverter(new ConverterFactory(converters));


            var temp = new Temperature(input,Unit.Celsius);
            var result = tc.Convert(temp,Unit.Kelvin);

            Assert.Equal<decimal>(expectedResult,Math.Round(result.Value,2));
        }

    }
}
