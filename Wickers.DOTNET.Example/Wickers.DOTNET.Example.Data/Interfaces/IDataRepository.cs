using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wickers.DOTNET.Example.Data.Models;

namespace Wickers.DOTNET.Example.Data.Interfaces
{
    public interface IDataRepository
    {
        Task<IEnumerable<T>> QueryData<T>(string ProcedureName, List<ParameterModel> Parameters = null);
        Task<ExampleModel> QuerySingle<ExampleModel>(string ProcedureName, Func<ExampleModel, bool> Expression);
    }
}