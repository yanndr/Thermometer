using System;

namespace ThermometerLibrary.Converter;

public interface ITemperatureConverter
{
    ITemperature Convert(ITemperature temperature, Unit unit);
}

public class TemperatureConverter:ITemperatureConverter
{
    private readonly IConverterFactory _converterFactory;

    public TemperatureConverter(IConverterFactory converterFactory)
    {
        this._converterFactory = converterFactory;
    }

    public ITemperature Convert(ITemperature temperature, Unit unit)
    {
        if(_converterFactory == null)
        {
            throw new Exception("There is no converters defined.");
        }

        if(temperature.Unit ==  unit)
        {
            return temperature;
        }

        ITemperature tempInKelvin;
        if (temperature.Unit == Unit.Kelvin)
        {
            tempInKelvin = temperature;
        }
        else
        {
            var fromConverter = GetConverter(temperature.Unit);
            tempInKelvin = fromConverter.ToKelvin(temperature);
        }

        if (unit == Unit.Kelvin)
        {
            return tempInKelvin;
        }

        var toConverter = GetConverter(unit);

        return toConverter.FromKelvin(tempInKelvin);
    }

    private IUnitConverter GetConverter(Unit unit)
    {   
        var converter = _converterFactory.GetConverter(unit);
        if(converter == null)
        {
            throw new Exception(
                $"No Converter were found for this unit: {unit}, please contact the dev, or create a new converter for the unit");
        }
        return converter;

    }
}