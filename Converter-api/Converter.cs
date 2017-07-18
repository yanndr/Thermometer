using System;
using System.Collections.Generic;
using TemperatureLibrary;
using TemperatureLibrary.Converter;

namespace Converter_api
{


    public sealed class Converter
    {
        private static volatile TemperatureConverter instance;
        private static object syncRoot = new Object();

        private Converter() {}

        public static TemperatureConverter Instance
        {
            get 
            {
                if (instance == null) 
                {
                    lock (syncRoot) 
                    {
                        if (instance == null) 
                            instance = new TemperatureConverter
                            (
                                new ConverterFactory
                                (
                                    new List<IUnitConverter>
                                    {
                                        new CelsiusConverter(),
                                        new FahrenheitConverter()
                                    }
                                )
                            );
                    }
                }

                return instance;
            }
        }
    }
}