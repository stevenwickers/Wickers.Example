using System.Collections.Generic;
using System.Threading.Tasks;
using Wickers.DOTNET.Example.Models;

namespace Wickers.DOTNET.Example.Business.Services.Interfaces
{
    public interface IExampleServices
    {
        Task<ExampleModel> SelectByKey(string Key);
        Task<List<ExampleModel>> Select();
    }
}