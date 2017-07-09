using System.Collections.Generic;

namespace TemperatureLibrary.Converter
{
    public interface IConverterFactory
    {
        ICollection<IUnitConverter> Converters {get;}
        IUnitConverter GetConverter(Unit unit);
    }
}