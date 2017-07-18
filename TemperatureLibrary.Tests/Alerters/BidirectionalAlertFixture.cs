using System;
using TemperatureLibrary.Alerters;
using Xunit;

namespace TemperatureLibrary.Tests.Alerters
{
    public class BidirectionalAlertFixture
    {
        private readonly BidirectionalAlert bidirectionalAlert;
        private const string alertName = "bidirectionalAlert";

        public BidirectionalAlertFixture()
        {
            bidirectionalAlert = new BidirectionalAlert(alertName, 10.0m,0.5m);    
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
            Assert.Throws<ArgumentNullException>(()=>new BidirectionalAlert(null, -50, -50));
        }

        [Fact]
        public void TemperatureRaisedToThresholdValueShouldReturnTrue()
        {
            var result = bidirectionalAlert.IsConditionReached(10.0M, 0.5M);
            Assert.True(result);
        }

        [Fact]
        public void TemperatureDropToThresholdValueShouldReturnTrue()
        {
            var result = bidirectionalAlert.IsConditionReached(10.0M, -0.5M);
            Assert.True(result);
        }

        [Fact]
        public void TemperatureDidNotReachThresholdValueShouldReturnFalse()
        {
            var result = bidirectionalAlert.IsConditionReached(11.0M, 0.5M);
            Assert.False(result);
        }

        [Fact]
        public void TemperatureReachedThresholdMutlipleTimeWithInsignificantFluctuationUpShouldReturnOneAlert()
        {
            var result = bidirectionalAlert.IsConditionReached(10.0M, 0.5M);
            Assert.True(result);

            result = bidirectionalAlert.IsConditionReached(9.8M, -0.2M);
            Assert.False(result);

            result = bidirectionalAlert.IsConditionReached(10.0M, 0.2M);
            Assert.False(result);

            result = bidirectionalAlert.IsConditionReached(9.5M, -0.5M);
            Assert.False(result);

            result = bidirectionalAlert.IsConditionReached(10.0M, 0.5M);
            Assert.False(result);
        }

        [Fact]
        public void TemperatureReachedThresholdMutlipleTimeWithInsignificantFluctuationDownShouldReturnOneAlert()
        {
            var result = bidirectionalAlert.IsConditionReached(10.0M, 0.5M);
            Assert.True(result);

            result = bidirectionalAlert.IsConditionReached(10.2M, 0.2M);
            Assert.False(result);

            result = bidirectionalAlert.IsConditionReached(10.0M, -0.2M);
            Assert.False(result);

            result = bidirectionalAlert.IsConditionReached(10.5M, 0.5M);
            Assert.False(result);

            result = bidirectionalAlert.IsConditionReached(10.0M, -0.5M);
            Assert.False(result);
        }

        [Fact]
        public void TemperatureReachedThresholdValueAndFluctuateUpMoreThanFluctuationAllowedShouldReturnMultipleAlert()
        {
            var result = bidirectionalAlert.IsConditionReached(10.0M, -0.5M);
            Assert.True(result, "The alert should be issued.");

            result = bidirectionalAlert.IsConditionReached(9.0M, -1M);
            Assert.False(result, "The alert shouldn't be issued.");

            result = bidirectionalAlert.IsConditionReached(10.0M, 1M);
            Assert.True(result, "The alert should be issued.");
        }

        [Fact]
        public void TemperatureReachedThresholdValueAndFluctuateDownMoreThanFluctuationAllowedShouldReturnMultipleAlert()
        {
            var result = bidirectionalAlert.IsConditionReached(10.0M, 0.5M);
            Assert.True(result, "The alert should be issued.");

            result = bidirectionalAlert.IsConditionReached(11.0M, 1M);
            Assert.False(result, "The alert shouldn't be issued.");

            result = bidirectionalAlert.IsConditionReached(10.0M, -1M);
            Assert.True(result, "The alert should be issued.");
        }
    }
}
