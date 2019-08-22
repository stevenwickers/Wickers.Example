using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Wickers.DOTNET.Example.Business.Services.Interfaces
{
    public interface ISQLServices
    {
        Task<T> SelectSingle<T>(string ProcedureName, Func<T, bool> Expression);
        Task<List<T>> Select<T>(string ProcedureName);
        
    }
}