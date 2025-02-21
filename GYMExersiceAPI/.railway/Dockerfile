# Этап сборки
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Копируем только файлы зависимостей для кеширования слоев
COPY GYMExersiceAPI/*.csproj GYMExersiceAPI/
RUN dotnet restore GYMExersiceAPI/GYMExersiceAPI.csproj --disable-parallel

# Теперь копируем весь исходный код
COPY . .
WORKDIR /src/GYMExersiceAPI

# Сборка и публикация
RUN dotnet publish -c Release -o /app --no-restore

# Этап выполнения
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Копируем собранный проект
COPY --from=build /app .

# Открываем порт (если используется)
EXPOSE 80

# Запуск приложения
ENTRYPOINT ["dotnet", "GYMExersiceAPI.dll"]
