namespace Server.Extensions;

public static class WebApplicationExtensions
{
    public static void UseDevelopmentServices(this IApplicationBuilder app)
    {
        app.UseOpenApi();
        app.UseSwaggerUi();
    }
    
    public static void ConfigureExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(new ExceptionHandlerOptions
        {
            StatusCodeSelector = ex => StatusCodes.Status500InternalServerError
        });
    }
}