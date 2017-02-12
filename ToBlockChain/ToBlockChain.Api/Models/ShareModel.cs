using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToBlockChain.Api.Models
{
    public class ShareModel
    {
        [JsonProperty("emailSender")]
        public string SenderEmail { get; set; }

        [JsonProperty("emailReceiver")]
        public string ReceiverEmail { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }
    }
}