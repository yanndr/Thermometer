using System;

namespace TemperatureLibrary.Converter
{
    public interface IConverterFactory
    {
        IConverter GetConverter(ITemperature temperature);
        IConverter GetConverter(Type temperatureType);
    }

    public class ConverterFactory:IConverterFactory
    {
        public IConverter GetConverter(ITemperature temperature)
        {
            
            if(temperature is Celcius)
            {
                return new CelciusConverter();
            }
            else if(temperature is FahrenheitConverter)
            {
                return new FahrenheitConverter();
            }
            
            return new KelvinConverter();
        }

        public IConverter GetConverter(Type temperatureType)
        {
            if (temperatureType == typeof(Celcius))
            {
                return new CelciusConverter();
            }
            else if(temperatureType == typeof(Fahrenheit)) 
            {
                return new FahrenheitConverter();
            }
            
            return new KelvinConverter();
        }
    }
}