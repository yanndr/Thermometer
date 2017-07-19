using TemperatureLibrary.Converter;
using TemperatureLibrary.Alerters;
using System.Collections.Generic;

namespace TemperatureLibrary
{
    public interface IThermometer
    {
        Unit ThermometerUnit { get; set; }
        ITemperature Temperature { get;}
        void HandleTemperatureChanged(object sender, TemperatureChangedEventArgs e);

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