using System;
using TemperatureLibrary.Converter;


namespace TemperatureLibrary
{
    public class MultiUnitThermometer: Thermometer, IMultiUnitThermometer
    {
        public ITemperatureConverter Converter{get;}

        public MultiUnitThermometer(Unit unit,ITemperatureConverter converter):base(unit)
        {
            this.Converter = converter;
        }

        public override void HandleTemperatureChanged(object sender, TemperatureChangedEventArgs e)
        {
            if (Temperature.Unit != e.Temperature.Unit && Converter == null)
            {
                throw new MemberAccessException(string.Format("There is no converters with this thermometer. A {0} unit was recieved but the thermometer is set to {1} unit.",e.Temperature.Unit,ThermometerUnit));
            }

            var temperature = e.Temperature.Unit != ThermometerUnit
                    ? Converter.Convert(e.Temperature, ThermometerUnit)
                    : e.Temperature;
            

            updateTemperature(temperature);
        }
    }
}