using System;
using ThermometerLibrary.Alerters;
using Xunit;

namespace ThermometerLibrary.Tests.Alerters
{
    public class DropAlertFixture
    {
        private readonly DropAlert dropAlert;
        private const string alertName = "dropAlert";
        private bool alertRaised;

        public DropAlertFixture()
        {
            dropAlert = new DropAlert(alertName, 10.0m, 0.5m, () => alertRaised = true);
        }

        [Fact]
        public void ConstructorTest()
        {
            Assert.Equal(alertName, dropAlert.Name);
            Assert.Equal(10.0M, dropAlert.ThresholdTemperature);
            Assert.Equal(0.5M, dropAlert.MinimumReleventFluctuation);
            Assert.Equal(false, dropAlert.IsAlertOn);
        }

        [Fact]
        public void ConstructorTestWithNullString()
        {
            Assert.Throws<ArgumentNullException>(() => new DropAlert(null, -50, -50, null));
        }

        [Fact]
        public void TemperatureRaisedToThresholdValueShouldReturnFalse()
        {
            alertRaised = false;
            dropAlert.Check(10.0M);
            Assert.False(alertRaised);
        }

        [Fact]
        public void TemperatureDropToThresholdValueShouldReturnTrue()
        {
            alertRaised = false;
            dropAlert.Check(15.0M);
            dropAlert.Check(10.0M);
            Assert.True(alertRaised);
        }

        [Fact]
        public void TemperatureDropBelowThresholdValueShouldReturnTrue()
        {
            alertRaised = false;
            dropAlert.Check(15.0M);
            dropAlert.Check(5.0M);
            Assert.True(alertRaised);
        }

        [Fact]
        public void TemperatureDropToThresholdValueOnceShouldReturnTrue()
        {
            alertRaised = false;
            dropAlert.Check(20.0m);
            Assert.False(alertRaised);
            dropAlert.Check(10.0M);
            Assert.True(alertRaised);
            alertRaised = false;
            dropAlert.Check(9.0M);
            Assert.False(alertRaised);
            alertRaised = false;
            dropAlert.Check(0.0M);
            Assert.False(alertRaised);
            alertRaised = false;
            dropAlert.Check(9.9M);
            Assert.False(alertRaised);
            alertRaised = false;
            dropAlert.Check(5.0M);
            Assert.False(alertRaised);
        }

        [Fact]
        public void TemperatureDidNotReachThresholdValueShouldReturnFalse()
        {
            alertRaised = false;
            dropAlert.Check(11.0M);
            Assert.False(alertRaised);
        }

        [Fact]
        public void TemperatureReachedThresholdMutlipleTimeWithInsignificantFluctuationUpShouldReturnOneAlert()
        {
            alertRaised = false;
            dropAlert.Check(15m);
            Assert.False(alertRaised);

            alertRaised = false;
            dropAlert.Check(10.0M);
            Assert.True(alertRaised);

            alertRaised = false;
            dropAlert.Check(9.8M);
            Assert.False(alertRaised);

            alertRaised = false;
            dropAlert.Check(10.0M);
            Assert.False(alertRaised);

            alertRaised = false;
            dropAlert.Check(9.5M);
            Assert.False(alertRaised);

            alertRaised = false;
            dropAlert.Check(10.0M);
            Assert.False(alertRaised);
        }

        [Fact]
        public void TemperatureReachedThresholdMutlipleTimeWithInsignificantFluctuationDownShouldReturnOneAlert()
        {
            alertRaised = false;
            dropAlert.Check(20.0M);
            Assert.False(alertRaised);

            alertRaised = false;
            dropAlert.Check(10.0M);
            Assert.True(alertRaised);

            alertRaised = false;
            dropAlert.Check(10.2M);
            Assert.False(alertRaised);

            alertRaised = false;
            dropAlert.Check(10.0M);
            Assert.False(alertRaised);

            alertRaised = false;
            dropAlert.Check(10.5M);
            Assert.False(alertRaised);

            alertRaised = false;
            dropAlert.Check(10.0M);
            Assert.False(alertRaised);
        }

        [Fact]
        public void TemperatureReachedThresholdValueAndFluctuateUpMoreThanFluctuationAllowedShouldReturnOneAlert()
        {
            alertRaised = false;
            dropAlert.Check(20.0M);
            Assert.False(alertRaised);

            alertRaised = false;
            dropAlert.Check(10.0M);
            Assert.True(alertRaised);

            alertRaised = false;
            dropAlert.Check(9.0M);
            Assert.False(alertRaised);

            alertRaised = false;
            dropAlert.Check(10.0M);
            Assert.False(alertRaised);
        }

        [Fact]
        public void TemperatureReachedThresholdValueAndFluctuateDownMoreThanFluctuationAllowedShouldReturnMultipleAlert()
        {
            alertRaised = false;
            dropAlert.Check(20.0M);
            Assert.False(alertRaised);

            alertRaised = false;
            dropAlert.Check(10.0M);
            Assert.True(alertRaised);

            alertRaised = false;
            dropAlert.Check(11.0M);
            Assert.False(alertRaised);

            alertRaised = false;
            dropAlert.Check(10.0M);
            Assert.True(alertRaised);
        }
    }
}
