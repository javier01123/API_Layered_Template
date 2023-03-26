using Microsoft.Extensions.Logging;

namespace App.Application.Loggers.Text
{
    public class TextFileLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new TextFileLogger(this);
        }

        public void Dispose()
        {
        }
    }
}
