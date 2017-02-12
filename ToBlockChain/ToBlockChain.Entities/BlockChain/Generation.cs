using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToBlockChain.Entities.BlockChain
{
    public class Generation
    {
        [JsonProperty("_emailId")]
        public string Email { get; set; }

        [JsonProperty("_deviceId")]
        public string DeviceId { get; set; }

        [JsonProperty("_generation")]
        public int GenerationInKW { get; set; }
    }
}
