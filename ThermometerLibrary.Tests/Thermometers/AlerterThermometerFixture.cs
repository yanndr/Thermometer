using System.Collections.Generic;
using Moq;
using ThermometerLibrary.Alerters;
using ThermometerLibrary.Converter;
using Xunit;

namespace ThermometerLibrary.Tests.Thermometers
{
    public class AlerterThermometerFixture
    {
        [Theory]
        [InlineData(Unit.Celsius)]
        [InlineData(Unit.Fahrenheit)]
        [InlineData(Unit.Kelvin)]
        public void ConstructorTest(Unit unit)
        {
            var converter = new Mock<ITemperatureConverter>();
            converter.Setup(x => x.Convert(It.IsAny<ITemperature>(), It.IsAny<Unit>()))
                .Returns(new Temperature(0.5m, Unit.Celsius));

            var alerterMock = new Mock<IAlerter>();

            var thermometer = new AlerterThermometer(unit, converter.Object, new List<IAlerter> { alerterMock.Object });

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
            var converter = new Mock<ITemperatureConverter>();
            converter.Setup(x => x.Convert(It.IsAny<ITemperature>(), It.IsAny<Unit>()))
                .Returns(new Temperature(0.5m, Unit.Celsius));

            var alerterMock = new Mock<IAlerter>();
            var thermometer = new AlerterThermometer(unit, converter.Object, new List<IAlerter>{alerterMock.Object});

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
        public void HandleTemperatureChangedWithDifferentUnit(Unit unit)
        {
            var converter = new Mock<ITemperatureConverter>();
            converter.Setup(x => x.Convert(It.IsAny<ITemperature>(), It.IsAny<Unit>()))
                .Returns(new Temperature(0.5m, Unit.Celsius));

            var alerterMock = new Mock<IAlerter>();

            var thermometer = new AlerterThermometer(Unit.Celsius,converter.Object, new List<IAlerter> { alerterMock.Object });

            
            thermometer.UpdateTemperature(new Temperature(10.5m, unit));
            Assert.Equal(0.5m, thermometer.Temperature.Value);
            Assert.Equal(Unit.Celsius, thermometer.Temperature.Unit);
        }

        [Fact]
        public void HandleTemperatureChangedWithAlerterTest()
        {
            var alertIssued = false;
            var alert = new BidirectionalAlert("test",10.5m,1m, () =>
            {
                alertIssued = true;
            });
           
            var alertList = new List<IAlerter>
            {
                alert
            };

            var thermometer = new AlerterThermometer(Unit.Celsius, null, alertList);

            thermometer.UpdateTemperature(new Temperature(0.5m, Unit.Celsius));
            thermometer.UpdateTemperature(new Temperature(10.5m, Unit.Celsius));
            Assert.Equal(10.5m, thermometer.Temperature.Value);
            Assert.Equal(Unit.Celsius, thermometer.Temperature.Unit);
            Assert.Equal(true, alertIssued);
        }
    }
}
