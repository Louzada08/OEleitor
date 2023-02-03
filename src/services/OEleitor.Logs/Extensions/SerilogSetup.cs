using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace OEleitor.Logs.Extensions
{
    public static class SerilogSetup
    {
        public static void ConfigureSerilog(IConfiguration configuration)
        {
            var logConfiguration = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration);

            Log.Logger = logConfiguration.CreateLogger();
        }

        public static IHostBuilder UsingSerilog(this IHostBuilder builder)
        {
            return builder.UseSerilog(Log.Logger);
        }

        public static IApplicationBuilder UsingSerilogRequestLogging(this IApplicationBuilder builder)
        {
            return builder.UseSerilogRequestLogging();
        }
    }
}