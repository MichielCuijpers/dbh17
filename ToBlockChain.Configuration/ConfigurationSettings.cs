using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToBlockChain.Configuration
{
    public class ConfigurationSettings : TableEntity
    {
        public string ConfigurationGroup { get; set; }

        public string AppKey { get; set; }

        public string AppSecret { get; set; }

        public string AppUrl { get; set; }
    }
}
