using Microsoft.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;

namespace App.Application.Loggers.Text
{

    public class TextFileLogger : ILogger
    {
        protected readonly TextFileLoggerProvider _textFileLoggerFileProvider;

        public TextFileLogger([NotNull] TextFileLoggerProvider roundTheCodeLoggerFileProvider)
        {
            _textFileLoggerFileProvider = roundTheCodeLoggerFileProvider;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel != LogLevel.None;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
                return;

            string logsFolder = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "logs");
            string filename = $"logs_{DateTime.Now.ToString("yyyy-MM-dd")}.log";
            string fullFilePath = Path.Combine(logsFolder, filename);
            string logRecord = string.Format("{0} [{1}] {2} {3}", "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss+00:00") + "]", logLevel.ToString(), formatter(state, exception) , exception != null ? exception.StackTrace : "");

            if (!Directory.Exists(logsFolder))
                Directory.CreateDirectory(logsFolder);

            using (var streamWriter = new StreamWriter(fullFilePath, true))
                streamWriter.WriteLine(logRecord);
        }
    }
}
