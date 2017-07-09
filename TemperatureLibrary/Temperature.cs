namespace TemperatureLibrary
{
    public class Temperature :ITemperature
    {
        public  decimal Value {get; set;}
        public Unit Unit {get; set;}

        public Temperature(decimal value,Unit unit){
            Value = value;
            Unit = unit;
        }

        public override string ToString(){
            return string.Format("{0}°{1}",Value,((char)Unit).ToString());
        } 

        public static bool operator ==(Temperature a, Temperature b)
        {
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            if (((object)a == null) || ((object)b == null))
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
            Temperature p = obj as Temperature;
            if ((object)p == null)
            {
                return false;
            }

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}