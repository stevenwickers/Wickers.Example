using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wickers.DOTNET.Example.Data.Interfaces;
using Wickers.DOTNET.Example.Data.Models;

namespace Wickers.DOTNET.Example.Data
{
    public class DataRepository : IDataRepository
    {
        private readonly string _connectionString;
        private readonly int _commandTimeout;

        /// <summary>
        /// SMTP Model is nullable for tesing purposes
        /// </summary>
        /// <param name="ConnectionString">Valid SQL Conneciton String</param>
        /// <param name="SmtpModel">Represents the SMTP Settings</param>
        public DataRepository(string ConnectionString, int CommandTimeout)
        {
            _connectionString = ConnectionString;
            _commandTimeout = CommandTimeout;
        }


        public async Task<T> QuerySingle<T>(string ProcedureName, Func<T,bool> Expression)
        {
            var task = Task.Factory.StartNew(() => MockData.GetMockExampleData());

            var taskResult = await task;
            List<T> results = taskResult as List<T>;

            return results.ToList().FirstOrDefault(Expression);
        }


        public async Task<IEnumerable<T>> QueryData<T>(string ProcedureName, List<ParameterModel> Parameters = null)
        {
            var task = Task.Factory.StartNew(() => MockData.GetMockExampleData());

            var taskResult = await task;
            return taskResult as List<T>;
        }
   
    }
}
