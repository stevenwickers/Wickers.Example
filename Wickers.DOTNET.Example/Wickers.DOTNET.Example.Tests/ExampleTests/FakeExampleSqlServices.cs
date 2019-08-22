using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wickers.DOTNET.Example.Business.Services.Interfaces;
using Wickers.DOTNET.Example.Models;

namespace Wickers.DOTNET.Example.Tests.ExampleTests
{
    internal class FakeExampleSqlServices : ISQLServices
    {
        private List<ExampleModel> data;

        public FakeExampleSqlServices(List<ExampleModel> data)
        {
            this.data = data;
        }

       
        public async Task<List<T>> Select<T>(string ProcedureName)
        {
            //Return Fake Data
            var task = Task.Factory.StartNew(() => data);

            //Get Resutls from Task
            var taskResults = await task as List<T>;

            //Return as List of RoleModel
            return taskResults as List<T>;
        }

        public async Task<T> SelectSingle<T>(string ProcedureName, Func<T, bool> Expression)
        {
            //Return Fake Data
            var task = Task.Factory.StartNew(() => data);

            //Get Resutls from Task
            List<T> taskResults = await task as List<T>;

            //Return as List of RoleModel
            return taskResults.ToList().FirstOrDefault(Expression);
        }

    }
}