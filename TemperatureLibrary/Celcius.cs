using System;

namespace TemperatureLibrary
{
    public class Celcius:TemperatureBase
    {
        const string celciusSymbole= "C";

        public Celcius():base(celciusSymbole){
        
        }

        public Celcius(decimal value):this()
        {
            Value = value;
        }
    }
}
