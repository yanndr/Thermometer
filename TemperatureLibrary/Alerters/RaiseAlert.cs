
using System;

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
        public RaiseAlert(string alertName, decimal thresholdTemperature, decimal minimumReleventFluctuation,Action action)
            : base(alertName, thresholdTemperature, minimumReleventFluctuation, action) { }

        /// <summary>
        /// Check if the condition is reached to issue the alert.
        /// </summary>
        /// <param name="temperature">The temperature to check.</param>
        /// <returns>A boolean if the condition is reached to spread the alert.</returns>
        public override void Check(decimal temperature)
        {
            var fluctuation = temperature - previousTemperature;
            previousTemperature = temperature;

            if (temperature != ThresholdTemperature)
            {
                if (!IsAlertOn)
                    return;
                if (ThresholdTemperature - MinimumReleventFluctuation > temperature)
                    IsAlertOn = false;
                return;
            }

            if (IsAlertOn)
                return;

            if (fluctuation <= 0)
                return;

            IsAlertOn = true;
            Alert();
        }
    }
}
