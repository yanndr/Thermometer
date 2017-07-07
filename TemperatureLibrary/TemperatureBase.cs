using System;

namespace TemperatureLibrary
{
    public abstract class TemperatureBase: ITemperature
    {
        public virtual decimal Value {get; set;}
        protected string Symbole {get; set;}
        
        protected TemperatureBase(string symbole){
            Value=0.0m;
            Symbole = symbole;
        }


        public override string ToString(){
            return string.Format("{0}°{1}",Value,Symbole);
        } 

        public static bool operator ==(TemperatureBase a, TemperatureBase b)
        {
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            return a.Value == b.Value;
        }

        public static bool operator !=(TemperatureBase a, TemperatureBase b)
        {
            return !(a == b);
        }

        public override bool Equals(System.Object obj)
        {
            TemperatureBase p = obj as TemperatureBase;
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