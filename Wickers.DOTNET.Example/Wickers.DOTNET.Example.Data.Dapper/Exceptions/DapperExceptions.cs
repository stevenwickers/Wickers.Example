using System;

namespace Wickers.DOTNET.Example.Data.Dapper.Exceptions
{
    [Serializable]
    public class DapperExceptions : Exception
    {
        public DapperExceptions() { }
        public DapperExceptions(string message) : base(message) { }
        public DapperExceptions(string message, Exception innerException) : base(message, innerException) { }
    }
}
