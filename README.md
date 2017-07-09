# Introduction
This is an implementation of a temperature unit converter (so far) in C#.

# Prerequistes
- .net Core or Docker

# Build and Test
Build the solution:
> dotnet restore

> dotnet build 


Run the tests:
> dotnet test ./TemperatureLibrary.Tests


# Run the Converter-api

Run the api with dotnet:
> cd Converter-api

> dotnet run -p Converter-api.csproj 


Run the api with Docker:
> docker build -t converter-api .

> docker run -it --rm converter-api
