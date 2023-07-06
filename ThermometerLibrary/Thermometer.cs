using System;

namespace ThermometerLibrary;

public class Thermometer : IThermometer
{
    public Unit ThermometerUnit { get; set; }
    public ITemperature Temperature { get; private set; }

    protected Thermometer()
    {
    }

    public Thermometer(Unit unit)
    {
        ThermometerUnit = unit;
        Temperature = new Temperature(0.0m, unit);
    }

    public virtual void UpdateTemperature(ITemperature temperature)
    {
        if (Temperature.Unit != temperature.Unit)
        {
            throw new Exception(
                $"Sorry this is a basic thermometer. A {temperature.Unit} unit was received but the thermometer is set to {ThermometerUnit} unit.");
        }

        Temperature = temperature;
    }
}

public class TemperatureChangedEventArgs : EventArgs
{
    public ITemperature Temperature { get; }

    public TemperatureChangedEventArgs(ITemperature temperature)
    {
        Temperature = temperature;
    }
}