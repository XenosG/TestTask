using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.API
{
    public class ApiMarketResponse
    {
        [JsonProperty("data")]
        public List<MarketAsset> Data { get; set; }
    }
}
