using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToBlockChain.Entities.BlockChain
{
    public class Share
    {
        [JsonProperty("_emailIdSender")]
        public string SenderEmail { get; set; }

        [JsonProperty("_emailIdReceiver")]
        public string ReceiverEmail { get; set; }

        [JsonProperty("_amount")]
        public int Amount { get; set; }
    }
}
