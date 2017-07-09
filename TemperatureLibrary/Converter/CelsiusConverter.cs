namespace TemperatureLibrary.Converter
{
    public class CelsiusConverter: IUnitConverter{
        public ITemperature FromKelvin(ITemperature temperature)
        {
            return new Temperature(temperature.Value-273.15m,Unit.Celsius);
        }

        public  ITemperature ToKelvin(ITemperature temperature)
        {
            return new Temperature(temperature.Value+273.15m,Unit.Celsius);
        }

         public bool IsApplicableToUnit(Unit unit)
         {
            return unit == Unit.Celsius;
         }
    }
}