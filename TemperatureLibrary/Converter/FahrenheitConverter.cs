namespace TemperatureLibrary.Converter
{
    public class FahrenheitConverter: IUnitConverter
    {
        public ITemperature FromKelvin(ITemperature temperature)
        {
            return new Temperature(temperature.Value* 9/5 -459.67m,Unit.Fahrenheit);
        }

        public  ITemperature ToKelvin(ITemperature temperature)
        {
            return new Temperature((temperature.Value+459.67m)*5/9,Unit.Fahrenheit);
        }

        public bool IsApplicableToUnit(Unit unit)
         {
            return unit == Unit.Fahrenheit;
         }
    }
}