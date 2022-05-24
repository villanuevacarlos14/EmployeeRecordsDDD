FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EmployeeRecord.WebApi/EmployeeRecord.WebApi.csproj", "EmployeeRecord.WebApi/"]
RUN dotnet restore "EmployeeRecord.WebApi/EmployeeRecord.WebApi.csproj"
COPY . .
WORKDIR "/src/EmployeeRecord.WebApi"
RUN dotnet build "EmployeeRecord.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EmployeeRecord.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmployeeRecord.WebApi.dll"]
