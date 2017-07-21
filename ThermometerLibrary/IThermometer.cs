using System.Collections.Generic;
using ThermometerLibrary.Alerters;
using ThermometerLibrary.Converter;

namespace ThermometerLibrary
{
    public interface IThermometer
    {
        Unit ThermometerUnit { get; set; }
        ITemperature Temperature { get; }
        void UpdateTemperature(ITemperature temperature);
    }

    public interface IMultiUnitThermometer
    {
        ITemperatureConverter Converter {get;}
    }

      public interface IAlerterThermometer
    {
        ICollection<IAlerter> Alerters {get;}
    }
}