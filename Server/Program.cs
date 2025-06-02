using Polly;
using Polly.Extensions.Http;
using Server.Extensions;
using Server.HttpClients;
using Server.HttpClients.Abstractions;

namespace Server;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.AddConfiguration();
        builder.ConfigureLogging();
        builder.AddCorsPolicies();
        
        builder.Services.AddProblemDetails();
        builder.Services.AddControllers();
        builder.Services.ConfigureOutPutCache();
        builder.Services.AddOpenApiDocument();
        
        builder.Services.AddHttpClient<IDummyJsonApiClient, DummyJsonApiClient>()
            .AddPolicyHandler(GetRetryPolicy())
            .AddPolicyHandler(GetCircuitBreakerPolicy());
        
        builder.Services.AddServices();

        var app = builder.Build();
        
        app.ConfigureExceptionHandler();

        if (app.Environment.IsDevelopment())
        {
            app.UseDevelopmentServices();
        }
       
        app.UseCors();
        app.UseHttpsRedirection();
        app.UseOutputCache();
        app.MapControllers();

        app.Run();
    }
    
    static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
            .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2,
                retryAttempt)));
    }
    
    static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .CircuitBreakerAsync(3, TimeSpan.FromSeconds(30));
    }
}