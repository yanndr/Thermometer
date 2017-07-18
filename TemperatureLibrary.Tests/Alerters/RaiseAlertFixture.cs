using TemperatureLibrary.Alerters;
using Xunit;

namespace TemperatureLibrary.Tests.Alerters
{
    public class RaiseAlertFixture
    {
        private readonly RaiseAlert alert;
        private const string alertName = "RaiseAlert";

        public RaiseAlertFixture()
        {
            alert = new RaiseAlert(alertName, 10.0m, 0.5m);
        }

        [Fact]
        public void ConstructorTest()
        {
            Assert.Equal(alertName, alert.Name);
            Assert.Equal(10.0M, alert.ThresholdTemperature);
            Assert.Equal(0.5M, alert.MinimumReleventFluctuation);
            Assert.Equal(false, alert.IsAlertOn);
        }

        [Fact]
        public void TemperatureRaisedToThresholdValueShouldReturnTrue()
        {
            var result = alert.IsConditionReached(10.0M, 0.5M);
            Assert.True(result);
        }

        [Fact]
        public void TemperatureDropsToThresholdValueShouldReturnFalse()
        {
            var result = alert.IsConditionReached(10.0M, -0.5M);
            Assert.False(result);
        }

        [Fact]
        public void TemperaturemDidNotReachThresholdValueShouldReturnFalse()
        {
            var result = alert.IsConditionReached(11.0M, 0.5M);
            Assert.False(result);
        }

        [Fact]
        public void TemperatureReachedThresholdValueMutlipleTimesWithInsignificantDropFluctuationShouldReturnOneAlert()
        {
            var result = alert.IsConditionReached(10.0M, 0.5M);
            Assert.True(result);

            result = alert.IsConditionReached(9.8M, -0.2M);
            Assert.False(result);

            result = alert.IsConditionReached(10.0M, 0.2M);
            Assert.False(result);

            result = alert.IsConditionReached(9.5M, -0.5M);
            Assert.False(result);

            result = alert.IsConditionReached(10.0M, 0.5M);
            Assert.False(result);
        }

        [Fact]
        public void TemperatureReachedThresholdValueMutlipleTimesWithInsignificantRaiseFluctuationShouldReturnOneAlert()
        {
            var result = alert.IsConditionReached(10.0M, 0.5M);
            Assert.True(result);

            result = alert.IsConditionReached(10.2M, 0.2M);
            Assert.False(result);

            result = alert.IsConditionReached(10.0M, -0.2M);
            Assert.False(result);

            result = alert.IsConditionReached(10.5M, 0.5M);
            Assert.False(result);

            result = alert.IsConditionReached(10.0M, -0.5M);
            Assert.False(result);
        }

        [Fact]
        public void TemperatureReachesThresholdValueMutlipleTimesWithSignificantDropFluctuationShouldReturnMultipleAlert()
        {
            var result = alert.IsConditionReached(10.0M, 0.5M);
            Assert.True(result);

            result = alert.IsConditionReached(9.0M, -1M);
            Assert.False(result);

            result = alert.IsConditionReached(10.0M, 1M);
            Assert.True(result);
        }

        [Fact]
        public void TemperatureReachesThresholdValueMutlipleTimesWithSignificantRaiseFluctuationShouldReturnOneAlert()
        {
            var result = alert.IsConditionReached(10.0M, 0.5M);
            Assert.True(result);

            result = alert.IsConditionReached(11.0M, 1M);
            Assert.False(result);

            result = alert.IsConditionReached(10.0M, -1M);
            Assert.False(result);
        }

        /// <summary>
        /// In this test I assume that if the temperature reaches the threshold value and continues to rise and then the temperature drops
        /// directly below the threshold value and returns to the threshold value it should return true only if the temperature 
        /// exceded the minimum relevent fluctuation. 
        /// </summary>
        [Fact]
        public void TemperatureReachesThresholdValueAndContinuesToRiseAndDropDirectlyUnderThresholdValue()
        {
            var result = alert.IsConditionReached(10.0M, 0.5M);
            Assert.True(result);

            result = alert.IsConditionReached(100.0M, 90.0M);
            Assert.False(result);

            result = alert.IsConditionReached(9.8M, -90.2M);
            Assert.False(result);

            result = alert.IsConditionReached(10M, 0.2M);
            Assert.False(result);

            result = alert.IsConditionReached(100.0M, 90.0M);
            Assert.False(result);

            result = alert.IsConditionReached(9M, -90.0M);
            Assert.False(result);

            result = alert.IsConditionReached(10M, 1.0M);
            Assert.True(result);
        }
    }
}
