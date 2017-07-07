using System;
using TemperatureLibrary;
using TemperatureLibrary.Converter;

namespace ThermometerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // var temp = new Celcius(5.0m);
            var tempK = new Kelvin(0.0m);
            var zeroC = new Celcius(0m);

            var tc = new TemperatureConverter(new ConverterFactory());


            var result = tc.Convert<Celcius>(tempK); 
            var result2= tc.Convert<Kelvin>(zeroC);


            // Console.WriteLine(temp.ToString());
            Console.WriteLine(result);
            Console.WriteLine(result2);

            Console.WriteLine(tc.Convert<Fahrenheit>(tempK));
            Console.WriteLine(tc.Convert<Fahrenheit>(zeroC));

            // var toKelv = (Kelvin)zeroC;


        }
    }
}
