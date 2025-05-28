using Homework.Extensions;
using Homework.HttpClients;
using Homework.HttpClients.Abstractions;
using Polly;
using Polly.Extensions.Http;

namespace Homework;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.AddConfiguration();
        builder.ConfigureLogging();

        builder.Services.AddControllers();
        builder.Services.ConfigureOutPutCache();
        builder.Services.AddOpenApiDocument();
        
        builder.Services.AddHttpClient<IDummyApiClient, DummyApiClient>()
            .AddPolicyHandler(GetRetryPolicy())
            .AddPolicyHandler(GetCircuitBreakerPolicy());
        
        builder.Services.AddServices();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseDevelopmentServices();
        }

        app.UseHttpsRedirection();
        // NOTE to self: This must be after UseCORS
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