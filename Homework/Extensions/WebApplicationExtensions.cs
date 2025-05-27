namespace Homework.Extensions;

public static class WebApplicationExtensions
{
    public static void UseDevelopmentServices(this IApplicationBuilder app)
    {
        app.UseOpenApi();
        app.UseSwaggerUi();
    }
}