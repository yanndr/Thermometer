FROM microsoft/dotnet

WORKDIR /Thermometer


# copy and build everything else
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o out
WORKDIR /Thermometer/Converter-api
ENTRYPOINT dotnet  out/Converter-api.dll