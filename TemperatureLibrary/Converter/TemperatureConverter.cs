using System;

namespace TemperatureLibrary.Converter
{
    public interface ITemperatureConverter
    {
        ITemperature Convert(ITemperature temperature, Unit unit);
    }

    public class TemperatureConverter:ITemperatureConverter
    {
        private IConverterFactory converterFactory;

        public TemperatureConverter(IConverterFactory converterFactory)
        {
            this.converterFactory = converterFactory;
        }

        public ITemperature Convert(ITemperature temperature, Unit unit)
        {
            if(temperature.Unit ==  unit)
            {
                return temperature;
            }

            var tempInKelvin = converterFactory.GetConverter(temperature.Unit).ToKelvin(temperature);

            var converter = converterFactory.GetConverter(unit);
            return converter.FromKelvin(tempInKelvin);
        }
    }
}