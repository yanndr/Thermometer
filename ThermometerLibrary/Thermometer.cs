using System;

namespace ThermometerLibrary
{
    public class Thermometer : IThermometer
    {
        public Unit ThermometerUnit { get; set; }
        public ITemperature Temperature { get; private set; }

        protected Thermometer() { }

        public Thermometer(Unit unit)
        {
            ThermometerUnit = unit;
            Temperature = new Temperature(0.0m,unit);
        }

        public virtual void UpdateTemperature(ITemperature temperature){
            if (Temperature.Unit != temperature.Unit)
            {
                throw new Exception(string.Format("Sorry this is a basic thermometer. A {0} unit was recieved but the thermometer is set to {1} unit.", temperature.Unit, ThermometerUnit));
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
}
