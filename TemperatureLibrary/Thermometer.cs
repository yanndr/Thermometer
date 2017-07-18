using System;
using System.Collections.Generic;
using TemperatureLibrary.Alerters;
using TemperatureLibrary.Converter;

namespace TemperatureLibrary
{
    public class Thermometer
    {
        private ICollection<IAlerter> alerters;
        public ITemperatureConverter converter;

        public event EventHandler<TemperatureAlertEventArgs> AlertEventHandler;

        public Unit ThermometerUnit { get; set; }
        public ITemperature Temperature { get; private set; }

        /// <summary>
        /// The fluctuation of the temperature since the last update.
        /// </summary>
        public decimal Fluctuation { get; protected set; }

        public Thermometer(Unit unit, ITemperatureConverter converter)
        {
            ThermometerUnit = unit;
            Temperature = new Temperature(0.0m,unit);
            this.converter = converter;
        }

        public virtual void HandleTemperatureChanged(object sender, TemperatureChangedEventArgs e)
        {
            if (Temperature.Unit != e.Temperature.Unit && converter == null)
            {
                throw new MemberAccessException(string.Format("There is no converters with this thermometer. A {0} unit was recieved but the thermometer is set to {1} unit.",e.Temperature.Unit,ThermometerUnit));
            }

            var temperature = e.Temperature.Unit != ThermometerUnit
                    ? converter.Convert(Temperature, ThermometerUnit)
                    : e.Temperature;
            

            Fluctuation = temperature.Value - Temperature.Value;
            Temperature = temperature;

            if (alerters == null)
                return;

            foreach (var alert in alerters)
            {
                if (alert.IsConditionReached(Temperature, Fluctuation))
                {
                    OnRaiseTemperatureAlertEvent(new TemperatureAlertEventArgs(alert.Name));
                }
            }
        }

        /// <summary>
        /// Issue the alert.
        /// </summary>
        /// <param name="e">The event args to pass to the event.</param>
        protected void OnRaiseTemperatureAlertEvent(TemperatureAlertEventArgs e)
        {
            AlertEventHandler?.Invoke(this, e);
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
        public Temperature Temperature { get; }

        public TemperatureChangedEventArgs(Temperature temperature)
        {
            Temperature = temperature;
        }
    }
}
