using System.Collections.Generic;
using Wickers.DOTNET.Example.Models;

namespace Wickers.DOTNET.Example.Data
{
    public class MockData
    {

        public static List<ExampleModel> GetMockExampleData()
        {
            return new List<ExampleModel>()
            {
               new ExampleModel(){ Key="0",Value="Zero"}
                ,new ExampleModel(){ Key="1",Value="One"}
                ,new ExampleModel(){ Key="2",Value="Two"}
                ,new ExampleModel(){ Key="3",Value="Three"}
                ,new ExampleModel(){ Key="4",Value="Four"}
            };
        }
    }
}
