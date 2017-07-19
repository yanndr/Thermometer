# Introduction
Work is in progress. I am updating a solution that I worte in 2011.
So Far, I added a converter, a thermometer and a some alerts.

I still need to fix some naming and comments.

There is a console project that shows how to use the library.

# Prerequistes
- .net Core or Docker

# Build and Test
Build the solution:
> dotnet restore

> dotnet build 


Run the tests:
> dotnet test ./TemperatureLibrary.Tests/TemperatureLibrary.Tests.csproj

# Run the Console example

Run the api with dotnet:
> 

> dotnet run -p Converter-api.csproj 

# Run the Converter-api

Run the api with dotnet:
> dotnet run -p ThermometerConsole/ThermometerConsole.csproj


Run the api with Docker:
- build the image:
> docker build -t converter-api .

- Run the container
> docker run -it --rm converter-api
