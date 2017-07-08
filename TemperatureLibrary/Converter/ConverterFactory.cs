using System;
using System.Collections.Generic;

namespace TemperatureLibrary.Converter
{
    public interface IConverterFactory
    {
        ICollection<IUnitConverter> Converters {get;}
        IUnitConverter GetConverter(Unit unit);
    }

    public class ConverterFactory:IConverterFactory
    {
        public ICollection<IUnitConverter> Converters {get; set;}

        public ConverterFactory(ICollection<IUnitConverter> converters){
            Converters = converters;
        }
        public IUnitConverter GetConverter(Unit unit)
        {
            
            foreach (var converter in Converters)
            {
                if (converter.IsApplicableToUnit(unit)){
                    return converter;
                }
            }

            return null;
        }

    }
}