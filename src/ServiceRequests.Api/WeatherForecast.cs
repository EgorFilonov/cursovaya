namespace ServiceRequests.Api;

/// <summary>
/// Прогноз погоды из шаблонного эндпоинта. Нужен, чтобы проверить Swagger до появления заявок.
/// </summary>
public class WeatherForecast
{
    /// <summary>
    /// Дата, на которую дан прогноз.
    /// </summary>
    public DateOnly Date { get; set; }

    /// <summary>
    /// Температура в градусах Цельсия.
    /// </summary>
    public int TemperatureC { get; set; }

    /// <summary>
    /// Температура в градусах Фаренгейта, посчитанная из <see cref="TemperatureC"/>.
    /// </summary>
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    /// <summary>
    /// Краткое словесное описание погоды.
    /// </summary>
    public string? Summary { get; set; }
}
