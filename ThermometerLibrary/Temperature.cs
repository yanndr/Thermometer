using System;

namespace ThermometerLibrary;

public class Temperature : ITemperature
{
    public decimal Value { get; set; }
    public Unit Unit { get; set; }

    public Temperature(decimal value, Unit unit)
    {
        Value = value;
        Unit = unit;
    }

    public override string ToString()
    {
        return $"{Math.Round(Value, 2)}°{((char)Unit).ToString()}";
    }

    public static bool operator ==(Temperature a, Temperature b)
    {
        if (ReferenceEquals(a, b))
        {
            return true;
        }

        if ((object)a == null || (object)b == null)
        {
            return false;
        }

        return a.Value == b.Value && a.Unit == b.Unit;
    }

    public static bool operator !=(Temperature a, Temperature b)
    {
        return !(a == b);
    }

    public override bool Equals(System.Object obj)
    {
        var p = obj as Temperature;
        return (object)p != null && base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}