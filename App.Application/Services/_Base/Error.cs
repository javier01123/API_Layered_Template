using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Services._Base
{
    public class Error
    {
        public Error(string property, string message)
        {
            Property = property;
            Message = message;
        }

        public Error(string message)
        {
            Message = message;
        }
        public string? Property { get; private set; }
        public string Message { get; private set; }
    }
}
