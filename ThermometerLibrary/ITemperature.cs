namespace ThermometerLibrary
{
    public interface ITemperature
    {
        decimal Value {get; set;}
        Unit Unit {get;}
    }
}