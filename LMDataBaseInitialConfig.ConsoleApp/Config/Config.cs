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

        [JsonProperty("initial_script_path")]
        public string InitialScriptPath { get; set; }

        [JsonProperty("version")]
        public string Version
        {
            get
            {
                return "beta 1";

            }
        }

    }

}
