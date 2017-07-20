using System;

namespace ThermometerLibrary.Alerters
{
    /// <summary>
    /// Represents an alert issued only when the threshold is reached when the temperature is droping.
    /// <remarks>
    /// <para>
    /// I assume in this case that the temperature must reach the exact threshold to raise the alert.
    /// Of course, to issue the alert if the threshold is exactly reached or exceeded, we can easily change the logic
    /// of the function of Validate or create another Alert with different expectation.
    /// </para>
    /// </remarks>
    /// </summary>
    public class DropAlert : AlertBase, IAlerter
    {
        public DropAlert(string alertName, decimal thresholdTemperature, decimal minimumReleventFluctuation,Action action)
            : base(alertName, thresholdTemperature, minimumReleventFluctuation,action) { }

        public override void Check(decimal temperature)
        {
            var fluctuation = temperature - previousTemperature;
            previousTemperature = temperature;

            if (temperature != ThresholdTemperature)
            {
                if (!IsAlertOn)
                    return;

                if (ThresholdTemperature + MinimumReleventFluctuation < temperature)
                    IsAlertOn = false;

                return;
            }

            if (IsAlertOn)
                return;

            if (fluctuation >= 0)
                return;

            IsAlertOn = true;
            Alert();
        }
    }
}
