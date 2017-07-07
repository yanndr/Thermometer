using System;

namespace TemperatureLibrary
{
    public class Kelvin:TemperatureBase
    {
        const string kelvinSymbole= "k";
        public Kelvin():base(kelvinSymbole){
        }

        public Kelvin(decimal value):this()
        {
            Value= value;
        }
    }
}
