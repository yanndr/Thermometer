using System;
using ThermometerLibrary.Alerters;
using Xunit;

namespace ThermometerLibrary.Tests.Alerters
{
    public class BidirectionalAlertFixture 
    {
        private readonly BidirectionalAlert bidirectionalAlert;
        private const string alertName = "bidirectionalAlert";
        private bool alertRaised;
       
        public BidirectionalAlertFixture()
        {
            alertRaised = false;
            bidirectionalAlert = new BidirectionalAlert(alertName, 10.0m,0.5m, () => { alertRaised = true; });    
        }

        [Fact]
        public void ConstructorTest()
        {
            Assert.Equal(alertName, bidirectionalAlert.Name);
            Assert.Equal(10.0M, bidirectionalAlert.ThresholdTemperature);
            Assert.Equal(0.5M, bidirectionalAlert.MinimumReleventFluctuation);
            Assert.Equal(false, bidirectionalAlert.IsAlertOn);
        }

        [Fact]
        public void ConstructorTestWithNullString()
        {
            Assert.Throws<ArgumentNullException>(()=>new BidirectionalAlert(null, -50, -50,null));
        }

        [Fact]
        public void TemperatureRaisedToThresholdValueShouldReturnTrue()
        {
            alertRaised = false;
            bidirectionalAlert.Check(10.0M);
            Assert.True(alertRaised);
        }

        [Fact]
        public void TemperatureDropToThresholdValueShouldReturnTrue()
        {
            alertRaised = false;
            bidirectionalAlert.Check(10.0M);
            Assert.True(alertRaised);
        }

        [Fact]
        public void TemperatureDidNotReachThresholdValueShouldReturnFalse()
        {
            alertRaised = false;
            bidirectionalAlert.Check(11.0M);
            Assert.False(alertRaised);
        }

        [Fact]
        public void TemperatureReachedThresholdMutlipleTimeWithInsignificantFluctuationUpShouldReturnOneAlert()
        {
             alertRaised = false;
            bidirectionalAlert.Check(10.0M);
            Assert.True(alertRaised);

            alertRaised = false;
            bidirectionalAlert.Check(9.8M);
            Assert.False(alertRaised);

            alertRaised = false;
            bidirectionalAlert.Check(10.0M);
            Assert.False(alertRaised);

            alertRaised = false;
            bidirectionalAlert.Check(9.5M);
            Assert.False(alertRaised);

            alertRaised = false;
            bidirectionalAlert.Check(10.0M);
            Assert.False(alertRaised);
        }

        [Fact]
        public void TemperatureReachedThresholdMutlipleTimeWithInsignificantFluctuationDownShouldReturnOneAlert()
        {
            alertRaised = false;
            bidirectionalAlert.Check(10.0M);
            Assert.True(alertRaised);

            alertRaised = false;
            bidirectionalAlert.Check(10.2M);
            Assert.False(alertRaised);

            alertRaised = false;
            bidirectionalAlert.Check(10.0M);
            Assert.False(alertRaised);

            alertRaised = false;
            bidirectionalAlert.Check(10.5M);
            Assert.False(alertRaised);

            alertRaised = false;
            bidirectionalAlert.Check(10.0M);
            Assert.False(alertRaised);
        }

        [Fact]
        public void TemperatureReachedThresholdValueAndFluctuateUpMoreThanFluctuationAllowedShouldReturnMultipleAlert()
        {
            alertRaised = false;
            bidirectionalAlert.Check(10.0M);
            Assert.True(alertRaised);

            alertRaised = false;
            bidirectionalAlert.Check(9.0M);
            Assert.False(alertRaised);

            alertRaised = false;
            bidirectionalAlert.Check(10.0M);
            Assert.True(alertRaised);
        }

        [Fact]
        public void TemperatureReachedThresholdValueAndFluctuateDownMoreThanFluctuationAllowedShouldReturnMultipleAlert()
        {
            alertRaised = false;
            bidirectionalAlert.Check(10.0M);
            Assert.True(alertRaised);

            alertRaised = false;
            bidirectionalAlert.Check(11.0M);
            Assert.False(alertRaised);

            alertRaised = false;
            bidirectionalAlert.Check(10.0M);
            Assert.True(alertRaised);
        }
    }
}
