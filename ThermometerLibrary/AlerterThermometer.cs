using System;
using System.Collections.Generic;
using ThermometerLibrary.Alerters;
using ThermometerLibrary.Converter;

namespace ThermometerLibrary;

public class AlerterThermometer: MultiUnitThermometer, IAlerterThermometer
{
    public  ICollection<IAlerter> Alerters {get;}

    private  event EventHandler<TemperatureChangedEventArgs> TemperatureChanged;

    public AlerterThermometer(Unit unit, ITemperatureConverter converter,ICollection<IAlerter> alerters):base(unit,converter)
    {
        foreach (var alerter in alerters)
        {
            TemperatureChanged += alerter.HandleTemperatureChanged;
        }
        Alerters = alerters;
    }

    public override void UpdateTemperature(ITemperature temperature)
    {
        base.UpdateTemperature(temperature);
        TemperatureChanged?.Invoke(null, new TemperatureChangedEventArgs(Temperature));
    }
}