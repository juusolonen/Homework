using Polly.CircuitBreaker;

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
            StatusCodeSelector = ex => ex switch
            {
                BrokenCircuitException => StatusCodes.Status503ServiceUnavailable,
              _ => StatusCodes.Status500InternalServerError  
            } 
        });
    }
}