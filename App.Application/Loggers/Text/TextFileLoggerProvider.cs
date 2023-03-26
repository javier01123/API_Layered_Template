using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
