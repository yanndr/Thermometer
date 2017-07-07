using System;

namespace TemperatureLibrary.Converter{
    public class KelvinConverter: IConverter{
        public ITemperature Convert(ITemperature temperature){
            if(temperature is Kelvin)
            {
             return temperature;
            }

            return new ConverterFactory().GetConverter(temperature).ToKelvin(temperature);
        }

        public  Kelvin ToKelvin(ITemperature temperature){
            return temperature as Kelvin;
        }
    }
}