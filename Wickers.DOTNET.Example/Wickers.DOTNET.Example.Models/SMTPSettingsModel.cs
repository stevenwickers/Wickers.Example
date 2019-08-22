using System;
using System.Collections.Generic;
using System.Text;

namespace Wickers.DOTNET.Example.Models
{
    public class SMTPSettingsModel
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Subject { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
    }
}
