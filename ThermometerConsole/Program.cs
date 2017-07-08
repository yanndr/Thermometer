using System;
using System.Collections.Generic;
using TemperatureLibrary;
using TemperatureLibrary.Converter;

namespace ThermometerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // var temp = new Celcius(5.0m);
            var tempK = new Temperature(0.0m,Unit.Kelvin);
            var zeroC = new Temperature(0m,Unit.Celsius);

            var converters = new List<IUnitConverter>();
            converters.Add(new KelvinConverter()); 
            converters.Add(new FahrenheitConverter()); 
            converters.Add(new CelciusConverter());

            var tc = new TemperatureConverter(new ConverterFactory(converters));


            var result = tc.Convert(tempK,Unit.Celsius); 
            var result2= tc.Convert(zeroC,Unit.Kelvin);


            // Console.WriteLine(temp.ToString());
            Console.WriteLine(result);
            Console.WriteLine(result2);

            Console.WriteLine(tc.Convert(tempK,Unit.Fahrenheit));
            Console.WriteLine(tc.Convert(zeroC,Unit.Fahrenheit));

            // var toKelv = (Kelvin)zeroC;


        }
    }
}
