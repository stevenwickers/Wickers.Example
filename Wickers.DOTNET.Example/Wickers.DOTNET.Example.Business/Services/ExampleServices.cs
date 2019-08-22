using System.Collections.Generic;
using System.Threading.Tasks;
using Wickers.DOTNET.Example.Business.Exceptions;
using Wickers.DOTNET.Example.Business.Services.Interfaces;
using Wickers.DOTNET.Example.Models;


namespace Wickers.DOTNET.Example.Business.Services
{
    public class ExampleServices : IExampleServices
    {
        private ISQLServices _repo;
        protected const string _schema = "dbo.";

        public ExampleServices(ISQLServices SqlServices) 
        {
            _repo = SqlServices;
        }

        /// <summary>
        /// Get Data from SQL EXAMPLE
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        public async Task<ExampleModel> SelectByKey(string Key)
        {
            try
            {
                return await _repo.SelectSingle<ExampleModel>($"{_schema}GetDataByKey", x => x.Key == Key);
            }
            catch (System.Exception e)
            {
                throw new BusinessExceptions(e.Message, e.InnerException);
            }
        }

       
        /// <summary>
        /// THIS IS JUST AN EXAMPLE....
        /// </summary>
        /// <returns></returns>
        public async Task<List<ExampleModel>> Select()
        {
            return await _repo.Select<ExampleModel>($"{_schema}GetData");
        }

    }
}
