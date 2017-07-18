using System;
using TemperatureLibrary.Alerters;
using Xunit;

namespace TemperatureLibrary.Tests.Alerters
{
    public class DropAlertFixture
    {
        private readonly DropAlert dropAlert;
        private const string alertName = "dropAlert";

        public DropAlertFixture()
        {
            dropAlert = new DropAlert(alertName, 10.0m,0.5m);    
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
            Assert.Throws<ArgumentNullException>(()=>new BidirectionalAlert(null, -50, -50));
        }

        [Fact]
        public void TemperatureRaisedToThresholdValueShouldReturnFalse()
        {
            var result = dropAlert.IsConditionReached(10.0M, 0.5M);
            Assert.False(result);
        }

        [Fact]
        public void TemperatureDropToThresholdValueShouldReturnTrue()
        {
            var result = dropAlert.IsConditionReached(10.0M, -0.5M);
            Assert.True(result);
        }

        [Fact]
        public void TemperatureDidNotReachThresholdValueShouldReturnFalse()
        {
            var result = dropAlert.IsConditionReached(11.0M, 0.5M);
            Assert.False(result);
        }

        [Fact]
        public void TemperatureReachedThresholdMutlipleTimeWithInsignificantFluctuationUpShouldReturnOneAlert()
        {
            var result = dropAlert.IsConditionReached(10.0M, -0.5M);
            Assert.True(result);

            result = dropAlert.IsConditionReached(9.8M, -0.2M);
            Assert.False(result);

            result = dropAlert.IsConditionReached(10.0M, 0.2M);
            Assert.False(result);

            result = dropAlert.IsConditionReached(9.5M, -0.5M);
            Assert.False(result);

            result = dropAlert.IsConditionReached(10.0M, 0.5M);
            Assert.False(result);
        }

        [Fact]
        public void TemperatureReachedThresholdMutlipleTimeWithInsignificantFluctuationDownShouldReturnOneAlert()
        {
            var result = dropAlert.IsConditionReached(10.0M, -0.5M);
            Assert.True(result);

            result = dropAlert.IsConditionReached(10.2M, 0.2M);
            Assert.False(result);

            result = dropAlert.IsConditionReached(10.0M, -0.2M);
            Assert.False(result);

            result = dropAlert.IsConditionReached(10.5M, 0.5M);
            Assert.False(result);

            result = dropAlert.IsConditionReached(10.0M, -0.5M);
            Assert.False(result);
        }

        [Fact]
        public void TemperatureReachedThresholdValueAndFluctuateUpMoreThanFluctuationAllowedShouldReturnOneAlert()
        {
            var result = dropAlert.IsConditionReached(10.0M, -0.5M);
            Assert.True(result, "The alert should be issued.");

            result = dropAlert.IsConditionReached(9.0M, -1M);
            Assert.False(result, "The alert shouldn't be issued.");

            result = dropAlert.IsConditionReached(10.0M, 1M);
            Assert.False(result, "The alert should be issued.");
        }

        [Fact]
        public void TemperatureReachedThresholdValueAndFluctuateDownMoreThanFluctuationAllowedShouldReturnMultipleAlert()
        {
            var result = dropAlert.IsConditionReached(10.0M, -0.5M);
            Assert.True(result, "The alert should be issued.");

            result = dropAlert.IsConditionReached(11.0M, 1M);
            Assert.False(result, "The alert shouldn't be issued.");

            result = dropAlert.IsConditionReached(10.0M, -1M);
            Assert.True(result, "The alert should be issued.");
        }
    }
}
