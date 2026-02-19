using Serilog;

namespace RestWithASPNET10Gerhard.Configurations;

public static class LoggingConfig
{
    public static void AddSerilogLogging(this WebApplicationBuilder builder)
    {
        builder.Logging.ClearProviders();

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .Enrich.FromLogContext()
            .CreateLogger();

        builder.Host.UseSerilog();
    }
}
