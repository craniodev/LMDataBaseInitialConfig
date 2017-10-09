using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMDataBaseInitialConfig.ConsoleApp.Config
{

    [JsonObject]
    public class Config
    {
        [JsonProperty("connection_strings")]
        public Dictionary<string, string> ConnectionStrings { get; set; }

        [JsonProperty("tables")]
        public List<ConfigTable> Tables { get; set; }

    }

}
