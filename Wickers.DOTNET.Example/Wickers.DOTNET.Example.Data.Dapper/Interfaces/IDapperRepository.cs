﻿using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Wickers.DOTNET.Example.Data.Dapper.Interfaces
{
    public interface IDapperRepository
    {
        Task<T> QuerySingle<T>(string ProcedureName, DynamicParameters Parameters = null);
        Task<IEnumerable<T>> QueryData<T>(string ProcedureName, DynamicParameters Parameters = null);
        Task<int> ExecuteProc(string ProcedureName, DynamicParameters Parameters);
        Task<T> ExecuteScalarProc<T>(string ProcedureName, DynamicParameters Parameters);

    }
}
