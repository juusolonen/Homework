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
        builder.Services.AddOptions<HomeworkConfiguration.DummyApi>()
            .Bind(builder.Configuration.GetRequiredSection(nameof(HomeworkConfiguration.DummyApi)));
    }
}