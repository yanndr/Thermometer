using System;

namespace TemperatureLibrary
{
    public interface ITemperature
    {
        decimal Value {get; set;}
        Unit Unit {get;}
    }
}