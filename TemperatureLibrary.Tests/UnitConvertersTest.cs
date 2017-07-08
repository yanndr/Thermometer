using System;
using Xunit;
using TemperatureLibrary;
using TemperatureLibrary.Converter;

namespace TemperatureLibrary.Tests
{
    public class ConverterTest
    {
        [Theory]
        [InlineData(0,273.15)]
        [InlineData(60,333.15)]
        [InlineData(25,298.15)]
        public void CelsuisToKelvin(decimal input, decimal expectedResult)
        {
            var cc = new CelsiusConverter();
            var temp = new Temperature(input,Unit.Celsius);
            var result = cc.ToKelvin(temp);

            Assert.Equal<decimal>(expectedResult,Math.Round(result.Value,2));
        }

        [Theory]
        [InlineData(273.15,0)]
        [InlineData(333.15,60)]
        [InlineData(298.15,25)]
        public void KelvinToCelsuis(decimal input, decimal expectedResult)
        {
            var cc = new CelsiusConverter();
            var temp = new Temperature(input,Unit.Celsius);
            var result = cc.FromKelvin(temp);

            Assert.Equal<decimal>(expectedResult,Math.Round(result.Value,2));
        }

        [Theory]
        [InlineData(0,255.37)]
        [InlineData(60,288.71)]
        [InlineData(25,269.26)]
        public void FahrenheitToKelvin(decimal input, decimal expectedResult)
        {
            var cc = new FahrenheitConverter();
            var temp = new Temperature(input,Unit.Celsius);
            var result = cc.ToKelvin(temp);

            Assert.Equal<decimal>(expectedResult,Math.Round(result.Value,2));
        }

        [Theory]
        [InlineData(0,-459.67)]
        [InlineData(59,-353.47)]
        [InlineData(300,80.33)]
        public void KelvinToCFahreinheit(decimal input, decimal expectedResult)
        {
            var cc = new FahrenheitConverter();
            var temp = new Temperature(input,Unit.Celsius);
            var result = cc.FromKelvin(temp);

            Assert.Equal<decimal>(expectedResult,Math.Round(result.Value,2));
        }
    }
}
