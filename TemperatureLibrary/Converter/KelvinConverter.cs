namespace TemperatureLibrary.Converter
{
    public class KelvinConverter: IUnitConverter{
        public ITemperature FromKelvin(ITemperature temperature){
            return temperature;
        }

        public  ITemperature ToKelvin(ITemperature temperature){
            return temperature;
        }

        public bool IsApplicableToUnit(Unit unit)
         {
            return unit == Unit.Kelvin;
         }
    }
}