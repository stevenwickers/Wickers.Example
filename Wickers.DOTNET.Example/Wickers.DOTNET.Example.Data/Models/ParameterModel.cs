using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Wickers.DOTNET.Example.Data.Models
{
    public class ParameterModel
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public DbType DataType { get; set; }
        public ParameterDirection Direction { get; set; }
        public int Size { get; set; }
    }
}
