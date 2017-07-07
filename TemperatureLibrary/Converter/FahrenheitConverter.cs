using System;

namespace TemperatureLibrary.Converter{
    public class FahrenheitConverter: IConverter{
        public ITemperature FromKelvin(Kelvin temperature){
            return new Fahrenheit(temperature.Value* 9/5 -459.67m);
        }

        public  Kelvin ToKelvin(ITemperature temperature){
            return new Kelvin((temperature.Value+459.67m)*5/9);
        }
    }
}