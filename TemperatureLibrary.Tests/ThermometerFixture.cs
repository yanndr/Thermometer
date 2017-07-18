using Xunit;

namespace TemperatureLibrary.Tests
{
    public class ThermometerFixture
    {
        [Theory]
        [InlineData(Unit.Celsius)]
        [InlineData(Unit.Fahrenheit)]
        [InlineData(Unit.Kelvin)]
        public void ConstructorTest(Unit unit)
        {
            var thermometer = new Thermometer(unit);

            Assert.Equal(unit, thermometer.ThermometerUnit);
            Assert.Equal(unit,thermometer.Temperature.Unit);
            Assert.Equal(0.0m, thermometer.Temperature.Value);
        }

        [Theory]
        [InlineData(Unit.Celsius)]
        [InlineData(Unit.Fahrenheit)]
        [InlineData(Unit.Kelvin)]
        public void HandleTemperatureChangedWithSameUnitAndNoAlertsTest(Unit unit)
        {
            var thermometer = new Thermometer(unit);

            thermometer.HandleTemperatureChanged(null,new TemperatureChangedEventArgs(new Temperature(10.5m,unit)));

            Assert.Equal(10.5m, thermometer.Temperature.Value);
            Assert.Equal(unit, thermometer.Temperature.Unit);
            Assert.Equal(10.5m,thermometer.Fluctuation);

            thermometer.HandleTemperatureChanged(null, new TemperatureChangedEventArgs(new Temperature(5.5m, unit)));
            Assert.Equal(5.5m, thermometer.Temperature.Value);
            Assert.Equal(unit, thermometer.Temperature.Unit);
            Assert.Equal(-5.0m, thermometer.Fluctuation);
        }

        [Theory]
        [InlineData(Unit.Fahrenheit)]
        [InlineData(Unit.Kelvin)]
        public void HandleTemperatureChangedWithDifferentUnitAndNoAlertsTest(Unit unit)
        {
            var thermometer = new Thermometer(Unit.Celsius);

            thermometer.HandleTemperatureChanged(null, new TemperatureChangedEventArgs(new Temperature(10.5m, unit)));

            Assert.Equal(10.5m, thermometer.Temperature.Value);
            Assert.Equal(unit, thermometer.Temperature.Unit);
            Assert.Equal(10.5m, thermometer.Fluctuation);

            thermometer.HandleTemperatureChanged(null, new TemperatureChangedEventArgs(new Temperature(5.5m, unit)));
            Assert.Equal(5.5m, thermometer.Temperature.Value);
            Assert.Equal(unit, thermometer.Temperature.Unit);
            Assert.Equal(-5.0m, thermometer.Fluctuation);
        }

    }
}
