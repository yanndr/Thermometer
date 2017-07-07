using System;

namespace TemperatureLibrary.Converter{
    public class FahrenheitConverter: IConverter{
        public ITemperature Convert(ITemperature temperature){
            if(temperature is Fahrenheit)
            {
             return temperature;
            }

            var temp = new ConverterFactory().GetConverter(temperature).ToKelvin(temperature);

            return new Fahrenheit(temp.Value* 9/5 -459.67m);
        }

        public  Kelvin ToKelvin(ITemperature temperature){
            return new Kelvin((temperature.Value+459.67m)*5/9);
        }
    }
}