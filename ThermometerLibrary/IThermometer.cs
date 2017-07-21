using System.Collections.Generic;
using ThermometerLibrary.Alerters;
using ThermometerLibrary.Converter;

namespace ThermometerLibrary
{
    public interface IMultiUnitThermometer
    {
        ITemperatureConverter Converter {get;}
    }

      public interface IAlerterThermometer
    {
        ICollection<IAlerter> Alerters {get;}
    }
}