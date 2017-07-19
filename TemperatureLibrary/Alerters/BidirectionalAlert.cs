
using System;

namespace TemperatureLibrary.Alerters
{
    /// <summary>
    /// Represents an alert issued when the temperature is reached if the temperature is droping or raising.
    /// </summary>
    public class BidirectionalAlert : AlertBase, IAlerter
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="alertName">The name of the alert to identifiy it.</param>
        /// <param name="thresholdTemperature"> The threshold value of the alert.</param>
        /// <param name="minimumReleventFluctuation">The minimum fluctuation considered relevent for alert.</param>
        public BidirectionalAlert(string alertName, decimal thresholdTemperature, decimal minimumReleventFluctuation,Action action)
            : base(alertName, thresholdTemperature, minimumReleventFluctuation,action) { }

        /// <summary>
        /// Check if the condition is reached to spread the alert.
        /// </summary>
        /// <param name="temperature">The temperature to check.</param>
        /// <returns>A boolean if the condition is reached to spread the alert.</returns>
        public void Check(decimal temperature)
        {
            if (temperature != ThresholdTemperature)
            {
                if (!IsAlertOn) return;

                if (ThresholdTemperature - MinimumReleventFluctuation > temperature)
                    IsAlertOn = false;

                if (ThresholdTemperature + MinimumReleventFluctuation < temperature)
                    IsAlertOn = false;
                return;
            }

            if (IsAlertOn)
                return;

            IsAlertOn = true;
            Alert();
        }
    }
}
