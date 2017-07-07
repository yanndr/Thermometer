using System;

namespace TemperatureLibrary.Converter{
    public interface IConverter{
        // ITemperature Convert(ITemperature temperature);
        Kelvin ToKelvin(ITemperature temperature);

        ITemperature FromKelvin(Kelvin temperature);
    }
}