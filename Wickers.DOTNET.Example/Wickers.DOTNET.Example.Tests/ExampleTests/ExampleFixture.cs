using System;
using System.Collections.Generic;
using Wickers.DOTNET.Example.API.Controllers;
using Wickers.DOTNET.Example.Business.Services;
using Wickers.DOTNET.Example.Business.Services.Interfaces;
using Wickers.DOTNET.Example.Models;

namespace Wickers.DOTNET.Example.Tests.ExampleTests
{
    public class ExampleFixture : BaseFixture, IDisposable
    {
        public ExeampleController ApiController;
        public ISQLServices SqlServices;
        public IExampleServices ExpService;
        
        public void WireupFixture(List<ExampleModel> Data = null)
        {
            //See the SQL Service with Fake Data
            SqlServices = new FakeExampleSqlServices(Data);

            //Create instance of Example Service
            ExpService = new ExampleServices(SqlServices);

            //Create instance of API
            ApiController = new ExeampleController(ExpService);

        }

        void IDisposable.Dispose()
        {
            SqlServices = null;
            ExpService = null;
            ApiController = null;
        }
    }
}
