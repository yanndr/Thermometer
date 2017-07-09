# Introduction
This is an implementation of a temperature unit converter (so far) in C#.

# Prerequistes
- .net Core or Docker

# Build and Test
...
> dotnet restore
> dotnet build 
...

Tests:
...
> dotnet test ./TemperatureLibrary.Tests
...

# Run the Converter-api

...
> cd Converter-api
> dotnet run -p Converter-api.csproj 
...

or with Docker:
 
...
> docker build -t converter-api .
> docker run -it --rm converter-api
...
