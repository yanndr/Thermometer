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

        public override void UpdateTemperature(ITemperature temperature)
        {
            if (Temperature.Unit != temperature.Unit && Converter == null)
            {
                throw new MemberAccessException(string.Format("There is no converters with this thermometer. A {0} unit was recieved but the thermometer is set to {1} unit.",temperature.Unit,ThermometerUnit));
            }

            var temp = temperature.Unit != ThermometerUnit
                    ? Converter.Convert(temperature, ThermometerUnit)
                    : temperature;
            

            base.UpdateTemperature(temp);
        }
    }
}