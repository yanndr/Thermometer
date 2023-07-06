using System;

namespace ThermometerLibrary.Alerters;

/// <summary>
/// Base class of an alert.
/// </summary>
public abstract class AlertBase: IAlerter
{
    /// <summary>
    /// The name of the alert to identify it.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The threshold value of the alert.
    /// </summary>
    public decimal ThresholdTemperature { get; }

    /// <summary>
    /// The minimum fluctuation considered relevant for alert.
    /// </summary>
    public decimal MinimumRelevantFluctuation { get; }

    /// <summary>
    /// Flag to indicate if the alert is in the threshold value or on the allowed fluctuation range.
    /// </summary>
    public bool IsAlertOn { get; protected set; }

    protected decimal PreviousTemperature;

    protected readonly Action Alert;

    protected AlertBase(string alertName, decimal thresholdTemperature, decimal minimumRelevantFluctuation,Action alert)
    {
        Name = alertName ?? throw new ArgumentNullException(nameof(alertName));
        ThresholdTemperature = thresholdTemperature;
        MinimumRelevantFluctuation = minimumRelevantFluctuation;
        IsAlertOn = false;
        Alert = alert;
    }

    public  void HandleTemperatureChanged(object sender, TemperatureChangedEventArgs e)
    {
        Check(e.Temperature.Value);
    }

    public virtual void Check(decimal temperature)
    {
    }
}