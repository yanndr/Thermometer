using System;

namespace TemperatureLibrary
{
    public class Fahrenheit:TemperatureBase
    {
        const string celciusSymbole= "F";

        public Fahrenheit():base(celciusSymbole){
        
        }

        public Fahrenheit(decimal value):this()
        {
            Value = value;
        }
    }
}
