using System;
using System.Collections.Generic;
using System.Text;

namespace Wickers.DOTNET.Example.Business.Models
{
    public class ServiceResults<T>
    {
        public bool Success { get; set; } = false;
        public string ErrorMessage { get; set; }
        public T Item { get; set; }
        public List<T> Items { get; set; }
    }
}
