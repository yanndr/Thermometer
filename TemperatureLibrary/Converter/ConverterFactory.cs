using System.Collections.Generic;
using System.Linq;

namespace TemperatureLibrary.Converter
{
    public class ConverterFactory:IConverterFactory
    {
        public ICollection<IUnitConverter> Converters {get; set;}

        public ConverterFactory(ICollection<IUnitConverter> converters){
            Converters = converters;
        }
        public IUnitConverter GetConverter(Unit unit)
        {
            return Converters.FirstOrDefault(Converter => Converter.IsApplicableToUnit(unit));
        }

    }
}