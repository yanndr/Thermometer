namespace ThermometerLibrary.Alerters;

public interface IAlerter
{
    string Name { get; set; }
    void Check(decimal temperature);
    void HandleTemperatureChanged(object sender, TemperatureChangedEventArgs e);
}