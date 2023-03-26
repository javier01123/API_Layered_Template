using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace App.Application.Loggers.Text
{
    public static class TextFileLoggerDIExtension
    {
        public static IServiceCollection AddTextFileLogging(this IServiceCollection services)
        {
            return services.AddSingleton<ILoggerProvider, TextFileLoggerProvider>();
        }
    }
}
