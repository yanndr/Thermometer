[![Build Status](https://travis-ci.org/yanndr/Thermometer.svg?branch=dev)](https://travis-ci.org/yanndr/Thermometer)

# Introduction
This is a C# .net core Temperature/Thermometer Library.

This library allows you to convert temperature units, so far Kelvin, Celsius and Fahrenheit.

There are three thermometers: Basic Thermometer, MultiUnit Thermometer and an AlerterThermometer. 

The Alerter Thermometer allows you to set up temperature thresholds to receive an alert when the temperature reaches your chosen threshold.  

# Usage

```
var converter = new TemperatureConverter(new ConverterFactory(
    new List<IUnitConverter>
    {
        new CelsiusConverter(),
        new FahrenheitConverter()
    }));

var alerters = new List<IAlerter>
{
    new DropAlert("Freezing alert", 0.0m, 0.5m,()=>Console.WriteLine("----Freezing Alert------s")),
    new RaiseAlert("Boiling alert", 100, 0.5m,()=>Console.WriteLine("----Boiling Alert----")),
    new BidirectionalAlert("Nice temperature alert", 28.0m, 1m,()=>Console.WriteLine("----Other Alert------s"))
};

thermometer = new AlerterThermometer(Unit.Celsius,converter, alerters);
```

In the solution you will find an example console project that shows how to use the library: thermometer-console .

# Prerequistes
```
- .net Core or Docker
```

# Build and Test
Build the solution:
```
> dotnet restore
> dotnet build 
```

Run the tests:
```
> dotnet test ./ThermometerLibrary.Tests/ThermometerLibrary.Tests.csproj
```

# Run the Console example

Run the example with dotnet:
```
> dotnet run -p ThermometerConsole/ThermometerConsole.csproj
```

Run the example with Docker:
```
- build the image:
> docker build -t thermometer-console .
```

- Run the container
```
> docker run -it --rm thermometer-console
```