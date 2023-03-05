using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Common.Exceptions
{
    public class BadRequestEx:Exception
    {
        public BadRequestEx(string message) : base(message) { }
    }
}
