# Introduction
This is a C# .net core Temperature/Thermometer Library.
This library allows you to convert temperature unit, so far Kelvin, Celsius and Fahrenheit.
There is some Thermometers functionalities: Basic Thermometer, Multiunit Thermometer and a AlerterThermometer. 
The Alerter Thermometer allows you to set up some temperature thresholds to receive an alert when the temperature reach the temperature.  

#Usage

There is a console project that shows how to use the library:thermometer-console .

# Prerequistes
- .net Core or Docker

# Build and Test
Build the solution:
> dotnet restore

> dotnet build 

Run the tests:
> dotnet test ./TemperatureLibrary.Tests/TemperatureLibrary.Tests.csproj

# Run the Console example

Run the example with dotnet:

> dotnet run -p Converter-api.csproj 


Run the example with Docker:
- build the image:
> docker build -t thermometer-console .

- Run the container
> docker run -it --rm thermometer-console
