using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wickers.DOTNET.Example.API.Models
{
    public class ApplicationSettingsModel
    {
        public string Name { get; set; }
        public string Environment { get; set; }
        public string SqlConnectionString { get; set; }
        public int SqlTimeout { get; set; }
    }
}
