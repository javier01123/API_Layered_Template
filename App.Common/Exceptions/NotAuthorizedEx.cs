using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Common.Exceptions
{
    public class NotAuthorizedEx:Exception
    {
        public NotAuthorizedEx(string message) : base(message) {}
    }
}
