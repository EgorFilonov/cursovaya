# Информационная система учёта заявок сервисного центра

Курсовая работа: веб-API для учёта заявок на обслуживание техники.

Система регистрирует заявку (клиент, описание неисправности, приоритет), хранит её и позволяет менять статус: принята, в работе, выполнена, отменена. Стек: ASP.NET Core Web API на .NET 10, PostgreSQL, Swagger (OpenAPI).

## Запуск

Профиль `http` открывает Swagger UI:

```bash
dotnet run --project src/ServiceRequests.Api --launch-profile http
```

Страница: `http://localhost:5128/swagger/index.html`. Сборка и тесты NUnit:

```bash
dotnet build --configuration Release
dotnet test --configuration Release
```
