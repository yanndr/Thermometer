using System;
using TemperatureLibrary.Alerters;
using TemperatureLibrary.Converter;
using System.Collections.Generic;


namespace TemperatureLibrary
{
    public class AlerterThermometer: MultiUnitThermometer, IAlerterThermometer
    {
         public  ICollection<IAlerter> Alerters {get;}

        public AlerterThermometer(Unit unit, ITemperatureConverter converter,ICollection<IAlerter> alerters):base(unit,converter)
        {
            Alerters = alerters;
        }

        public override void HandleTemperatureChanged(object sender, TemperatureChangedEventArgs e)
        {
            base.HandleTemperatureChanged(sender,e);

            if (Alerters == null)
                return;

            foreach (var alert in Alerters)
            {
                alert.Check(Temperature.Value);
            }
        }
    }
}