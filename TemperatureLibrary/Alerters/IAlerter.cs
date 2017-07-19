﻿using System;

namespace TemperatureLibrary.Alerters
{
    public interface IAlerter
    {
        string Name { get; set; }
        void Check(decimal tempererature);
        void HandleTemperatureChanged(object sender, TemperatureChangedEventArgs e);
    }
}