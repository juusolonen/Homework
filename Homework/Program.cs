using Homework.Extensions;

namespace Homework;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddControllers();
        
        builder.Services.AddOutputCache(opt =>
        {
            opt.AddPolicy(Constants.Cache.FiveSeconds, policyBuilder =>
            {
                policyBuilder.Expire(TimeSpan.FromSeconds(5));
            });
        });
        
        builder.Services.AddOpenApiDocument();
        
        builder.Services.AddServices();

        builder.ConfigureLogging();

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
}