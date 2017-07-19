using System;
using System.Collections.Generic;
using Moq;
using TemperatureLibrary.Alerters;
using TemperatureLibrary.Converter;
using Xunit;

namespace TemperatureLibrary.Tests.Thermometers
{
    public class MultiUnitThermometerFixture
    {
        [Theory]
        [InlineData(Unit.Celsius)]
        [InlineData(Unit.Fahrenheit)]
        [InlineData(Unit.Kelvin)]
        public void ConstructorTest(Unit unit)
        {
            var thermometer = new MultiUnitThermometer(unit,null);

            Assert.Equal(unit, thermometer.ThermometerUnit);
            Assert.Equal(unit,thermometer.Temperature.Unit);
            Assert.Equal(0.0m, thermometer.Temperature.Value);
        }

        [Theory]
        [InlineData(Unit.Celsius)]
        [InlineData(Unit.Fahrenheit)]
        [InlineData(Unit.Kelvin)]
        public void HandleTemperatureChangedWithSameUnit(Unit unit)
        {
            var thermometer = new MultiUnitThermometer(unit,null);

            thermometer.HandleTemperatureChanged(null,new TemperatureChangedEventArgs(new Temperature(10.5m,unit)));

            Assert.Equal(10.5m, thermometer.Temperature.Value);
            Assert.Equal(unit, thermometer.Temperature.Unit);

            thermometer.HandleTemperatureChanged(null, new TemperatureChangedEventArgs(new Temperature(5.5m, unit)));
            Assert.Equal(5.5m, thermometer.Temperature.Value);
            Assert.Equal(unit, thermometer.Temperature.Unit);
        }

        [Theory]
        [InlineData(Unit.Fahrenheit)]
        [InlineData(Unit.Kelvin)]
        public void HandleTemperatureChangedWithDifferentUnit(Unit unit)
        {
            var thermometer = new MultiUnitThermometer(Unit.Celsius,null);

            Assert.Throws<MemberAccessException>(() => thermometer.HandleTemperatureChanged(null, new TemperatureChangedEventArgs(new Temperature(10.5m, unit)))); 
        }

        [Theory]
        [InlineData(Unit.Fahrenheit)]
        [InlineData(Unit.Kelvin)]
        public void HandleTemperatureChangedWithDifferentUnitTest(Unit unit)
        {
            var converter = new Mock<ITemperatureConverter>();
            converter.Setup(x => x.Convert(It.IsAny<ITemperature>(), It.IsAny<Unit>()))
                .Returns(new Temperature(0.5m, Unit.Celsius));
            var thermometer = new MultiUnitThermometer(Unit.Celsius,converter.Object);

            
            thermometer.HandleTemperatureChanged(null, new TemperatureChangedEventArgs(new Temperature(10.5m, unit)));
            Assert.Equal(0.5m, thermometer.Temperature.Value);
            Assert.Equal(Unit.Celsius, thermometer.Temperature.Unit);
        }
    }
}
