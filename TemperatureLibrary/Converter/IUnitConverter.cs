using System;

namespace TemperatureLibrary.Converter{
    public interface IUnitConverter{
        ITemperature ToKelvin(ITemperature temperature);
        ITemperature FromKelvin(ITemperature temperature);
        bool IsApplicableToUnit(Unit unit);
    }
}