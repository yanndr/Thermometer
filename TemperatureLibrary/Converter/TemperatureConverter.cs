using System;

namespace TemperatureLibrary.Converter
{
    public interface ITemperatureConverter
    {
        T Convert<T>(ITemperature temperature);
    }

    public class TemperatureConverter:ITemperatureConverter
    {
        private IConverterFactory converterFactory;

        public TemperatureConverter(IConverterFactory converterFactory)
        {
            this.converterFactory = converterFactory;
        }

        public T Convert<T>(ITemperature temperature)
        {
            if(temperature is T)
            {
                return (T)temperature;
            }

            var tempInKelvin = converterFactory.GetConverter(temperature).ToKelvin(temperature);

            var converter = converterFactory.GetConverter(typeof(T));
            return (T)converter.FromKelvin(tempInKelvin);

        }
    }
}