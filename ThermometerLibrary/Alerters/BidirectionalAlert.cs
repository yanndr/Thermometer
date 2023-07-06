using System;

namespace ThermometerLibrary.Alerters;

/// <summary>
/// Represents an alert issued when the exact temperature is reached if the temperature is dropping or raising.
/// </summary>
public class BidirectionalAlert : AlertBase
{
    public BidirectionalAlert(string alertName, decimal thresholdTemperature, decimal minimumRelevantFluctuation,Action action)
        : base(alertName, thresholdTemperature, minimumRelevantFluctuation,action) { }

    public override void Check(decimal temperature)
    {
        if (temperature != ThresholdTemperature)
        {
            if (!IsAlertOn) return;

            if (ThresholdTemperature - MinimumRelevantFluctuation > temperature)
                IsAlertOn = false;

            if (ThresholdTemperature + MinimumRelevantFluctuation < temperature)
                IsAlertOn = false;
            return;
        }

        if (IsAlertOn)
            return;

        IsAlertOn = true;
        Alert();
    }
}