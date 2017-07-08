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
            if(converterFactory == null)
            {
                throw new Exception("There is no converters defined.");
            }

            if(temperature.Unit ==  unit)
            {
                return temperature;
            }

            var fromConverter = GetConverter(temperature.Unit);
            var tempInKelvin = fromConverter.ToKelvin(temperature);
            var toConverter = GetConverter(unit);

            return toConverter.FromKelvin(tempInKelvin);
        }

        private IUnitConverter GetConverter(Unit unit)
        {   
            var converter = converterFactory.GetConverter(unit);
            if(converter == null)
            {
                throw new Exception(string.Format("No Converter were found for this unit: {0}, please contact the dev, or create a new converter for the unit",unit));
            }
            return converter;

        }
    }
}