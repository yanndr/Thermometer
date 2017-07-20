using System.Collections.Generic;

namespace ThermometerLibrary.Converter
{
    public interface IConverterFactory
    {
        ICollection<IUnitConverter> Converters {get;}
        IUnitConverter GetConverter(Unit unit);
    }
}