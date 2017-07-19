using System;

namespace TemperatureLibrary.Alerters
{
    public interface IAlerter
    {
        string Name { get; set; }
        void Check(decimal tempererature);
        void HandleTemperatureChanged(object sender, TemperatureChangedEventArgs e);
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