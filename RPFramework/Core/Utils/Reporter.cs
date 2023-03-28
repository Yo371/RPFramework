using ReportPortal.Serilog;
using RPFramework.Core.Configuration;
using Serilog;
using Serilog.Events;

namespace RPFramework.Core.Utils
{
    public class Reporter
    {
        private static ILogger _logger;

        static Reporter()
        {
            _logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .ReadFrom
                .Configuration(ConfigManager.Configuration)
                .CreateLogger();
        }

        public static void Log(string message)
        {
            _logger.Write(LogEventLevel.Information, message);
        }
    }
}
