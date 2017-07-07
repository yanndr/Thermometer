using System;

namespace TemperatureLibrary.Converter{
    public class CelciusConverter: IConverter{
        public ITemperature FromKelvin(Kelvin temperature)
        {
            return new Celcius(temperature.Value-273.15m);
        }

        public  Kelvin ToKelvin(ITemperature temperature)
        {
            return new Kelvin(temperature.Value+273.15m);
        }
    }
}