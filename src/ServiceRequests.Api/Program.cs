using Swashbuckle.AspNetCore;

namespace ServiceRequests.Api;

/// <summary>
/// Точка входа веб-API учёта заявок сервисного центра.
/// </summary>
public class Program
{
    /// <summary>
    /// Собирает приложение, подключает контроллеры, OpenAPI и Swagger UI.
    /// </summary>
    /// <param name="args">Аргументы командной строки.</param>
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddOpenApi();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            // Подключаем классический Swagger UI и указываем путь к новому документу
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/openapi/v1.json", "v1");
            });
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
