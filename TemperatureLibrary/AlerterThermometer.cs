using System;
using TemperatureLibrary.Alerters;
using TemperatureLibrary.Converter;
using System.Collections.Generic;


namespace TemperatureLibrary
{
    public class AlerterThermometer: MultiUnitThermometer, IAlerterThermometer
    {
         public  ICollection<IAlerter> Alerters {get;}
         public event EventHandler<TemperatureAlertEventArgs> AlertEventHandler;

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
                if (alert.IsConditionReached(Temperature.Value, Fluctuation))
                {
                    OnRaiseTemperatureAlertEvent(new TemperatureAlertEventArgs(alert.Name));
                }
            }
        }

        protected void OnRaiseTemperatureAlertEvent(TemperatureAlertEventArgs e)
        {
            AlertEventHandler?.Invoke(this, e);
        }
    }
}