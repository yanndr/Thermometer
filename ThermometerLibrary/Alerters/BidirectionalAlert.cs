using System;

namespace ThermometerLibrary.Alerters
{
    /// <summary>
    /// Represents an alert issued when the exact temperature is reached if the temperature is droping or raising.
    /// </summary>
    public class BidirectionalAlert : AlertBase
    {
        public BidirectionalAlert(string alertName, decimal thresholdTemperature, decimal minimumReleventFluctuation,Action action)
            : base(alertName, thresholdTemperature, minimumReleventFluctuation,action) { }

        public override void Check(decimal temperature)
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
