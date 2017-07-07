using System;

namespace TemperatureLibrary.Converter{
    public class KelvinConverter: IConverter{
        public ITemperature FromKelvin(Kelvin temperature){
            return temperature;
        }

        public  Kelvin ToKelvin(ITemperature temperature){
            return temperature as Kelvin;
        }
    }
}