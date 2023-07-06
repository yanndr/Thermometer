using System.Collections.Generic;
using System.Linq;

namespace ThermometerLibrary.Converter;

public class ConverterFactory:IConverterFactory
{
    public ICollection<IUnitConverter> Converters {get; set;}

    public ConverterFactory(ICollection<IUnitConverter> converters){
        Converters = converters;
    }

    public IUnitConverter GetConverter(Unit unit)
    {
        return Converters.FirstOrDefault(converter => converter.IsApplicableToUnit(unit));
    }

}