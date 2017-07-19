using System;



namespace TemperatureLibrary
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

        protected void updateTemperature(ITemperature temperature){
            Temperature = temperature;
        }

        public virtual void HandleTemperatureChanged(object sender, TemperatureChangedEventArgs e)
        {
            if (Temperature.Unit != e.Temperature.Unit)
            {
                throw new Exception(string.Format("Sorry this is a basic thermometer. A {0} unit was recieved but the thermometer is set to {1} unit.",e.Temperature.Unit,ThermometerUnit));
            }

            updateTemperature(e.Temperature);
        }
    }

    /// <summary>
    /// Class containing the data of a temperature changed event. 
    /// </summary>
    public class TemperatureChangedEventArgs : EventArgs
    {
        /// <summary>
        /// The value of the temperature change.
        /// </summary>
        public ITemperature Temperature { get; }

        public TemperatureChangedEventArgs(ITemperature temperature)
        {
            Temperature = temperature;
        }
    }
}
