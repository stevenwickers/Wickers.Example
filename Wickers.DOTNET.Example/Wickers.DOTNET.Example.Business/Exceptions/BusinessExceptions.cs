using System;
using System.Collections.Generic;
using System.Text;

namespace Wickers.DOTNET.Example.Business.Exceptions
{
    public class BusinessExceptions : Exception
    {
        public BusinessExceptions() { }
        public BusinessExceptions(string message) : base(message) { }
        public BusinessExceptions(string message, Exception innerException) : base(message, innerException) { }

    }
}
