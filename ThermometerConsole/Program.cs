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

            var cc = new CelciusConverter();
            var kc = new KelvinConverter();
            var fc = new FahrenheitConverter();

            var result = cc.Convert(tempK); 
            var result2= kc.Convert(zeroC);


            // Console.WriteLine(temp.ToString());
            Console.WriteLine(result);
            Console.WriteLine(result2);

            Console.WriteLine(fc.Convert(tempK));
            Console.WriteLine(fc.Convert(zeroC));

            // var toKelv = (Kelvin)zeroC;


        }
    }
}
