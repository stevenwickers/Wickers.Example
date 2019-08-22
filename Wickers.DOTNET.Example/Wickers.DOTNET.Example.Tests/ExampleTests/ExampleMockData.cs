using System.Collections.Generic;
using Wickers.DOTNET.Example.Models;

namespace Wickers.DOTNET.Example.Tests.ExampleTests
{
    public class ExampleMockData
    {
        public static List<ExampleModel> GetMockExampleData()
        {
            return new List<ExampleModel>()
            {
               new ExampleModel(){ Key="20",Value="Twenty"}
                ,new ExampleModel(){ Key="21",Value="TwentyOne"}
                ,new ExampleModel(){ Key="22",Value="TwentyTwo"}
                ,new ExampleModel(){ Key="23",Value="TwentyThree"}
                ,new ExampleModel(){ Key="24",Value="TwentyFour"}
            };
        }
    }
}
