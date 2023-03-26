using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
