using System;
using ThermometerLibrary.Converter;

namespace ThermometerLibrary
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
                throw new MemberAccessException(
                    $"There is no converters with this thermometer. A {temperature.Unit} unit was recieved but the thermometer is set to {ThermometerUnit} unit.");
            }

            var temp = temperature.Unit != ThermometerUnit
                    ? Converter.Convert(temperature, ThermometerUnit)
                    : temperature;
            

            base.UpdateTemperature(temp);
        }
    }
}