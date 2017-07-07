using System;

namespace TemperatureLibrary.Converter
{
    public interface IConverterFactory
    {
        IConverter GetConverter(ITemperature temperature);
    }

    public class ConverterFactory:IConverterFactory
    {
        public IConverter GetConverter(ITemperature temperature)
        {
            
            if(temperature is Celcius)
            {
                return new CelciusConverter();
            }
            else if (temperature is Kelvin)
            {
                return new KelvinConverter();
            }
            else if(temperature is FahrenheitConverter)
            {
                return new FahrenheitConverter();
            }
            
            return null;
        }
    }
}