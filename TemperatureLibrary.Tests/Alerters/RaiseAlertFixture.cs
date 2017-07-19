using TemperatureLibrary.Alerters;
using Xunit;

namespace TemperatureLibrary.Tests.Alerters
{
    public class RaiseAlertFixture
    {
        private readonly RaiseAlert alert;
        private const string alertName = "RaiseAlert";
        private bool alertRaised;

        public RaiseAlertFixture()
        {
            alert = new RaiseAlert(alertName, 10.0m, 0.5m, ()=> { alertRaised = true; });
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
            alertRaised = false;
            alert.Check(10.0M);
            Assert.True(alertRaised);
        }

        [Fact]
        public void TemperatureDropsToThresholdValueShouldReturnFalse()
        {
            alert.Check(11.0M);
            alertRaised = false;
            alert.Check(10.0M);
            Assert.False(alertRaised);
        }

        [Fact]
        public void TemperaturemDidNotReachThresholdValueShouldReturnFalse()
        {
            alertRaised = false;
            alert.Check(11.0M);
            Assert.False(alertRaised);
        }

        [Fact]
        public void TemperatureReachedThresholdValueMutlipleTimesWithInsignificantDropFluctuationShouldReturnOneAlert()
        {
            alertRaised = false;
            alert.Check(10.0M);
            Assert.True(alertRaised);

            alertRaised = false;
            alert.Check(9.8M);
            Assert.False(alertRaised);

            alertRaised = false;
            alert.Check(10.0M);
            Assert.False(alertRaised);

            alertRaised = false;
            alert.Check(9.5M);
            Assert.False(alertRaised);

            alertRaised = false;
            alert.Check(10.0M);
            Assert.False(alertRaised);
        }

        [Fact]
        public void TemperatureReachedThresholdValueMutlipleTimesWithInsignificantRaiseFluctuationShouldReturnOneAlert()
        {
            alertRaised = false;
            alert.Check(10.0M);
            Assert.True(alertRaised);

            alertRaised = false;
            alert.Check(10.2M);
            Assert.False(alertRaised);

            alertRaised = false;
            alert.Check(10.0M);
            Assert.False(alertRaised);

            alertRaised = false;
            alert.Check(10.5M);
            Assert.False(alertRaised);

            alertRaised = false;
            alert.Check(10.0M);
            Assert.False(alertRaised);
        }

        [Fact]
        public void TemperatureReachesThresholdValueMutlipleTimesWithSignificantDropFluctuationShouldReturnMultipleAlert()
        {
            alertRaised = false;
            alert.Check(10.0M);
            Assert.True(alertRaised);

            alertRaised = false;
            alert.Check(9.0M);
            Assert.False(alertRaised);

            alertRaised = false;
            alert.Check(10.0M);
            Assert.True(alertRaised);
        }

        [Fact]
        public void TemperatureReachesThresholdValueMutlipleTimesWithSignificantRaiseFluctuationShouldReturnOneAlert()
        {
            alertRaised = false;
            alert.Check(10.0M);
            Assert.True(alertRaised);

            alertRaised = false;
            alert.Check(11.0M);
            Assert.False(alertRaised);

            alertRaised = false;
            alert.Check(10.0M);
            Assert.False(alertRaised);
        }

        /// <summary>
        /// In this test I assume that if the temperature reaches the threshold value and continues to rise and then the temperature drops
        /// directly below the threshold value and returns to the threshold value it should return true only if the temperature 
        /// exceded the minimum relevent fluctuation. 
        /// </summary>
        [Fact]
        public void TemperatureReachesThresholdValueAndContinuesToRiseAndDropDirectlyUnderThresholdValue()
        {
            alertRaised = false;
            alert.Check(10.0M);
            Assert.True(alertRaised);

            alertRaised = false;
            alert.Check(100.0M);
            Assert.False(alertRaised);

            alertRaised = false;
            alert.Check(9.8M);
            Assert.False(alertRaised);

            alertRaised = false;
            alert.Check(10M);
            Assert.False(alertRaised);

            alertRaised = false;
            alert.Check(100.0M);
            Assert.False(alertRaised);

            alertRaised = false;
            alert.Check(9M);
            Assert.False(alertRaised);

            alertRaised = false;
            alert.Check(10M);
            Assert.True(alertRaised);
        }
    }
}
