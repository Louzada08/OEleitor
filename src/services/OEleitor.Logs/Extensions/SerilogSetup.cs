using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace OEleitor.Logs.Extensions
{
    public static class SerilogSetup
    {
        private static LogEventLevel rollingInterval;

        public static void ConfigureSerilog(IConfiguration configuration)
        {
            var logConfiguration = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration);

            Log.Logger = logConfiguration.CreateLogger();

            //Log.Logger = new LoggerConfiguration()
            //    .WriteTo.Console()
            //    .WriteTo.File(@"c:\inetpub\logs\logOEleitor.txt").CreateLogger();
        }

        public static IHostBuilder UsingSerilog(this IHostBuilder builder)
        {
            return builder.UseSerilog(Log.Logger);
        }

        public static IApplicationBuilder UsingSerilogRequestLogging(this IApplicationBuilder builder)
        {
            return builder.UseSerilogRequestLogging();
        }
        public static void SalvaSerilog(string mensagem)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(@"c:\inetpub\logs\logOEleitor.txt").CreateLogger();

            Log.Information(mensagem);
        }
    }
}