
namespace TemperatureLibrary.Alerters
{
    /// <summary>
    /// Represents an alert issued only when the threshold is reached when the temperature is rising.
    /// </summary>
    public class RaiseAlert : AlertBase, IAlerter
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="alertName">The name of the alert to identifiy it.</param>
        /// <param name="thresholdTemperature"> The threshold value of the alert.</param>
        /// <param name="minimumReleventFluctuation">The minimum fluctuation considered relevent for alert.</param>
        public RaiseAlert(string alertName, decimal thresholdTemperature, decimal minimumReleventFluctuation)
            : base(alertName, thresholdTemperature, minimumReleventFluctuation) { }

        /// <summary>
        /// Check if the condition is reached to issue the alert.
        /// </summary>
        /// <param name="temperature">The temperature to check.</param>
        /// <param name="fluctuation">The last fluctuation of the thermometer.</param>
        /// <returns>A boolean if the condition is reached to spread the alert.</returns>
        public bool IsConditionReached(decimal temperature, decimal fluctuation)
        {

            if (temperature != ThresholdTemperature)
            {
                if (!IsAlertOn)
                    return false;
                if (ThresholdTemperature - MinimumReleventFluctuation > temperature)
                    IsAlertOn = false;
                return false;
            }

            if (IsAlertOn)
                return false;

            if (fluctuation <= 0)
                return false;

            IsAlertOn = true;
            return true;
        }
    }
}
