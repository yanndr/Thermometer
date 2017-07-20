
using System;

namespace ThermometerLibrary.Alerters
{
    /// <summary>
    /// Represents an alert issued only when the threshold is reached when the temperature is rising.
    /// </summary>
    public class RaiseAlert : AlertBase, IAlerter
    {
        public RaiseAlert(string alertName, decimal thresholdTemperature, decimal minimumReleventFluctuation,Action action)
            : base(alertName, thresholdTemperature, minimumReleventFluctuation, action) { }

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
