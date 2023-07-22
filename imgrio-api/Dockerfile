FROM mcr.microsoft.com/dotnet/sdk:7.0 AS publish

WORKDIR /src

COPY . .

RUN dotnet restore "./imgrio-api.csproj"
RUN dotnet publish "./imgrio-api.csproj" -c Release -o /app/publish --no-self-contained -r linux-x64

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final

WORKDIR /app
EXPOSE 80
EXPOSE 443
COPY --from=publish /app/publish .

COPY ./imgrio.com.pem /app/imgrio.com.pem
COPY ./imgrio.com.key /app/imgrio.com.key

ENTRYPOINT ["dotnet", "imgrio-api.dll", "--urls", "https://+:443"]