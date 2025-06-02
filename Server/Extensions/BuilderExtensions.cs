using NLog.Web;
using Server.Configuration;

namespace Server.Extensions;

public static class BuilderExtensions
{
    public static void ConfigureLogging(this WebApplicationBuilder builder)
    {
        builder.Logging.ClearProviders();
        builder.Host.UseNLog();
    }
    
    public static void AddConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.AddOptions<ServerConfiguration.DummyApi>()
            .Bind(builder.Configuration.GetRequiredSection(nameof(ServerConfiguration.DummyApi)));
    }
    
    public static void AddCorsPolicies(this WebApplicationBuilder builder)
    {
        var clientUrl = builder.Configuration.GetValue<string>(Constants.ClientUrl);
        ArgumentException.ThrowIfNullOrEmpty(clientUrl);
        
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.WithOrigins(clientUrl)
                    .WithMethods(["GET", "OPTIONS"]);
            });
        });
    }
}