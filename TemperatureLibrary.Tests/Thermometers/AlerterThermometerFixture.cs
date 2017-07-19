using System;
using System.Collections.Generic;
using Moq;
using TemperatureLibrary.Alerters;
using TemperatureLibrary.Converter;
using Xunit;

namespace TemperatureLibrary.Tests.Thermometers
{
    public class AlerterThermometerFixture
    {
        [Theory]
        [InlineData(Unit.Celsius)]
        [InlineData(Unit.Fahrenheit)]
        [InlineData(Unit.Kelvin)]
        public void ConstructorTest(Unit unit)
        {
            var thermometer = new AlerterThermometer(unit,null,null);

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
            var thermometer = new AlerterThermometer(unit,null,null);

            thermometer.UpdateTemperature(new Temperature(10.5m,unit));

            Assert.Equal(10.5m, thermometer.Temperature.Value);
            Assert.Equal(unit, thermometer.Temperature.Unit);

            thermometer.UpdateTemperature(new Temperature(5.5m, unit));
            Assert.Equal(5.5m, thermometer.Temperature.Value);
            Assert.Equal(unit, thermometer.Temperature.Unit);
        }

        [Theory]
        [InlineData(Unit.Fahrenheit)]
        [InlineData(Unit.Kelvin)]
        public void HandleTemperatureChangedWithDifferentUnitAndNoAlertsTest(Unit unit)
        {
            var thermometer = new AlerterThermometer(Unit.Celsius,null,null);

            Assert.Throws<MemberAccessException>(() => thermometer.UpdateTemperature(new Temperature(10.5m, unit))); 
        }

        [Theory]
        [InlineData(Unit.Fahrenheit)]
        [InlineData(Unit.Kelvin)]
        public void HandleTemperatureChangedWithDifferentUnitTest(Unit unit)
        {
            var converter = new Mock<ITemperatureConverter>();
            converter.Setup(x => x.Convert(It.IsAny<ITemperature>(), It.IsAny<Unit>()))
                .Returns(new Temperature(0.5m, Unit.Celsius));
            var thermometer = new AlerterThermometer(Unit.Celsius,converter.Object,null);

            
            thermometer.UpdateTemperature(new Temperature(10.5m, unit));
            Assert.Equal(0.5m, thermometer.Temperature.Value);
            Assert.Equal(Unit.Celsius, thermometer.Temperature.Unit);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void HandleTemperatureChangedWithAlerterTest(bool raiseAlert)
        {
            var alert = new Mock<IAlerter> {Name = "test"};

            var alertList = new List<IAlerter>
            {
                alert.Object
            };

            var thermometer = new AlerterThermometer(Unit.Celsius, null, alertList);
            var alertIssued = false;


            thermometer.UpdateTemperature(new Temperature(10.5m, Unit.Celsius));
            Assert.Equal(10.5m, thermometer.Temperature.Value);
            Assert.Equal(Unit.Celsius, thermometer.Temperature.Unit);
            Assert.Equal(raiseAlert, alertIssued);
        }
    }
}
