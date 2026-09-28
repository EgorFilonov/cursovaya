using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace ServiceRequests.Api.Tests;

/// <summary>
/// Проверяет, что шаблонный API отдаёт прогноз, документ OpenAPI и страницу Swagger.
/// </summary>
public class WeatherForecastEndpointTests
{
    private WebApplicationFactory<Program> _factory = null!;
    private HttpClient _client = null!;

    /// <summary>
    /// Поднимает приложение в памяти перед каждым тестом.
    /// </summary>
    [SetUp]
    public void SetUp()
    {
        _factory = new WebApplicationFactory<Program>();
        _client = _factory.CreateClient();
    }

    /// <summary>
    /// Освобождает клиент и фабрику после теста.
    /// </summary>
    [TearDown]
    public void TearDown()
    {
        _client.Dispose();
        _factory.Dispose();
    }

    /// <summary>
    /// GET /weatherforecast возвращает пять прогнозов.
    /// </summary>
    [Test]
    public async Task Get_returns_five_forecasts()
    {
        var response = await _client.GetAsync("/weatherforecast");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var body = await response.Content.ReadAsStringAsync();
        Assert.That(body, Does.Contain("temperatureC"));
        Assert.That(body, Does.Contain("summary"));
    }

    /// <summary>
    /// Документ OpenAPI публикуется по пути, который указан в Swagger UI.
    /// </summary>
    [Test]
    public async Task OpenApi_document_lists_weather_forecast()
    {
        var response = await _client.GetAsync("/openapi/v1.json");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var body = await response.Content.ReadAsStringAsync();
        Assert.That(body, Does.Contain("/WeatherForecast"));
        Assert.That(body, Does.Contain("WeatherForecast"));
    }

    /// <summary>
    /// Страница Swagger UI открывается по адресу из launchSettings.
    /// </summary>
    [Test]
    public async Task Swagger_ui_page_opens()
    {
        var response = await _client.GetAsync("/swagger/index.html");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var body = await response.Content.ReadAsStringAsync();
        Assert.That(body, Does.Contain("swagger"));
    }
}
