using System;
using System.Collections.Generic;
using Xunit;
using TemperatureLibrary;
using TemperatureLibrary.Converter;

namespace TemperatureLibrary.Tests
{
    public class TemperatureConverterFixture
    {

        TemperatureConverter temperatureConverter;
        public TemperatureConverterFixture(){
            var converters = new List<IUnitConverter>();
            converters.Add(new KelvinConverter()); 
            converters.Add(new FahrenheitConverter()); 
            converters.Add(new CelsiusConverter());

            temperatureConverter = new TemperatureConverter(new ConverterFactory(converters));
        }

        [Theory]
        [InlineData(0,273.15)]
        [InlineData(60,333.15)]
        [InlineData(25,298.15)]
        public void CelsuisToKelvin(decimal input, decimal expectedResult)
        {
            var temp = new Temperature(input,Unit.Celsius);
            var result = temperatureConverter.Convert(temp,Unit.Kelvin);

            Assert.Equal<decimal>(expectedResult,Math.Round(result.Value,2));
        }

        [Theory]
        [InlineData(0,32)]
        [InlineData(60,140)]
        [InlineData(25,77)]
        public void CelsuisToFahrenheit(decimal input, decimal expectedResult)
        {
            var temp = new Temperature(input,Unit.Celsius);
            var result = temperatureConverter.Convert(temp,Unit.Fahrenheit);

            Assert.Equal<decimal>(expectedResult,Math.Round(result.Value,2));
        }

        [Theory]
        [InlineData(32,0)]
        [InlineData(140,60)]
        [InlineData(77,25)]
        public void FahrenheitToCelsius(decimal input, decimal expectedResult)
        {
            var temp = new Temperature(input,Unit.Fahrenheit);
            var result = temperatureConverter.Convert(temp,Unit.Celsius);

            Assert.Equal<decimal>(expectedResult,Math.Round(result.Value,2));
        }

        [Theory]
        [InlineData(0,255.37)]
        [InlineData(60,288.71)]
        [InlineData(25,269.26)]
        public void FahrenheitToKelvin(decimal input, decimal expectedResult)
        {
            var temp = new Temperature(input,Unit.Fahrenheit);
            var result = temperatureConverter.Convert(temp,Unit.Kelvin);

            Assert.Equal<decimal>(expectedResult,Math.Round(result.Value,2));
        }

    }
}
