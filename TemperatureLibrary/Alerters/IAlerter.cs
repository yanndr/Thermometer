using System;

namespace TemperatureLibrary.Alerters
{
    public interface IAlerter
    {
        string Name { get; set; }
        bool IsConditionReached(decimal tempererature, decimal fluctuation);
    }

    /// <summary>
    /// Class containing the data of a temperature alert event. 
    /// </summary>
    public class TemperatureAlertEventArgs : EventArgs
    {
        /// <summary>
        /// The name of the alert issued.
        /// </summary>
        public string AlertName { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="alertName">The name of the alert issued.</param>
        public TemperatureAlertEventArgs(string alertName)
        {
            AlertName = alertName;
        }
    }
}