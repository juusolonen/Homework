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
            .AddPolicyHandlers();
        
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
}