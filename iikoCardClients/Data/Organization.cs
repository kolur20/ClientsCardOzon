using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iikoCardClients.Data
{
    class Organization
    {
        [JsonProperty("fullName")]
        public string Name { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("isActive")]
        public bool Active { get; set; }
    }
}
