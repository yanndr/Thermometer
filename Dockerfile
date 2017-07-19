FROM microsoft/dotnet

WORKDIR /Thermometer


# copy and build everything else
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o out
WORKDIR /Thermometer/ThermometerConsole
ENTRYPOINT dotnet  out/ThermometerConsole.dll