using System;

namespace TemperatureLibrary.Alerters
{
    /// <summary>
    /// Base class of an alert.
    /// </summary>
    public abstract class AlertBase
    {
        /// <summary>
        /// The name of the alert to identifiy it.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The threshold value of the alert.
        /// </summary>
        public decimal ThresholdTemperature { get; }

        /// <summary>
        /// The minimum fluctuation considered relevent for alert.
        /// </summary>
        public decimal MinimumReleventFluctuation { get; }

        /// <summary>
        /// Flag to indicate if the alert is in the threshold value or on the allowed fluctuation range.
        /// </summary>
        public bool IsAlertOn { get; protected set; }

        protected decimal previousTemperature;

        protected Action Alert;

        

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="alertName">The name of the alert to identifiy it.</param>
        /// <param name="thresholdTemperature"> The threshold value of the alert.</param>
        /// <param name="minimumReleventFluctuation">The minimum fluctuation considered relevent for alert.</param>
        protected AlertBase(string alertName, decimal thresholdTemperature, decimal minimumReleventFluctuation,Action alert)
        {
            if (alertName == null)
                throw new ArgumentNullException(nameof(alertName));

            Name = alertName;
            ThresholdTemperature = thresholdTemperature;
            MinimumReleventFluctuation = minimumReleventFluctuation;
            IsAlertOn = false;
            Alert = alert;
        }
    }
}
