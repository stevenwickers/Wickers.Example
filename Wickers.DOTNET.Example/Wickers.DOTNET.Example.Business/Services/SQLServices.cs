using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wickers.DOTNET.Example.Business.Services.Interfaces;
using Wickers.DOTNET.Example.Data;
using Wickers.DOTNET.Example.Data.Interfaces;
using Wickers.DOTNET.Example.Models;

namespace Wickers.DOTNET.Example.Business.Services
{

    public class SQLServices : ISQLServices
    {
        private IDataRepository _repo;

        public SQLServices(string ConnectionString, int SqlTimeout)
        {
            _repo = new DataRepository(ConnectionString, SqlTimeout);
        }
        
        public async Task<List<T>> Select<T>(String ProcedureName)
        {
            var results = await _repo.QueryData<T>(ProcedureName);

            if (results == null)
            {
                return new List<T>();
            }

            return results.ToList();
        }

        public async Task<T> SelectSingle<T>(String ProcedureName, Func<T,bool> Expression) 
        {
            return await _repo.QuerySingle<T>(ProcedureName, Expression);
        }
    }

}
