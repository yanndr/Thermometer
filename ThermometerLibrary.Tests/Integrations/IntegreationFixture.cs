using System.Collections.Generic;
using ThermometerLibrary.Alerters;
using ThermometerLibrary.Converter;
using Xunit;

namespace ThermometerLibrary.Tests.Integrations
{
    public class IntegreationFixture
    {
        private int numberOfAlert1;
        private int numberOfAlert2;
        private int numberOfAlert3;

        private IThermometer thermometer;

        public IntegreationFixture()
        {
            var converter = new TemperatureConverter(new ConverterFactory(new List<IUnitConverter> { new CelsiusConverter(), new FahrenheitConverter() }));

            var alerters = new List<IAlerter>
            {
                new DropAlert("Alert 1", 0.0m, 0.5m,()=>numberOfAlert1++),
                new RaiseAlert("Alert 2", 100, 0.5m,()=>numberOfAlert2++),
                new BidirectionalAlert("Alert 3", 28.0m, 1m,()=>numberOfAlert3++)
            };

            thermometer = new AlerterThermometer(Unit.Celsius, converter, alerters);

        }

        [Fact]
        public void BasicUsageTest()
        {
            foreach (var temperature in temperatures)
            {
                thermometer.UpdateTemperature(temperature);
            }

            Assert.Equal(2,numberOfAlert1);
            Assert.Equal(1,numberOfAlert2);
            Assert.Equal(2,numberOfAlert3);
        }

        private List<ITemperature> temperatures =
            new List<ITemperature>
            {
                new Temperature(15.0m, Unit.Kelvin),
                new Temperature(12.0m, Unit.Celsius),
                new Temperature(32.0m, Unit.Fahrenheit),
                new Temperature(0.1m, Unit.Celsius),
                new Temperature(0.0m,Unit.Celsius),
                new Temperature(23.0m,Unit.Celsius),
                new Temperature(27.9m,Unit.Celsius),
                new Temperature(28.0m,Unit.Celsius),
                new Temperature(28.3m,Unit.Celsius),
                new Temperature(28.0m,Unit.Celsius),
                new Temperature(35.0m,Unit.Celsius),
                new Temperature(28.0m,Unit.Celsius),
                new Temperature(70.0m,Unit.Celsius),
                new Temperature(100.0m,Unit.Celsius),
                new Temperature(110.0m,Unit.Celsius),
                new Temperature(10.0m,Unit.Celsius),
                new Temperature(35.0m,Unit.Kelvin),
                new Temperature(28.0m,Unit.Kelvin),
                new Temperature(70.0m,Unit.Kelvin),
                new Temperature(100.0m,Unit.Fahrenheit),
                new Temperature(32.0m,Unit.Fahrenheit),

            };
}
}
