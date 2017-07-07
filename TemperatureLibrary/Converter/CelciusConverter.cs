using System;

namespace TemperatureLibrary.Converter{
    public class CelciusConverter: IConverter{
        public ITemperature Convert(ITemperature temperature)
        {
            if(temperature is Celcius)
            {
             return temperature;
            }

            var temp = new ConverterFactory().GetConverter(temperature).ToKelvin(temperature);

            return new Celcius(temp.Value-273.15m);
        }

        public  Kelvin ToKelvin(ITemperature temperature)
        {
            return new Kelvin(temperature.Value+273.15m);
        }
    }
}