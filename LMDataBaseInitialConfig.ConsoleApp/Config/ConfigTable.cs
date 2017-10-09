using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMDataBaseInitialConfig.ConsoleApp.Config
{

    [JsonObject]
    public class ConfigTable
    {

        public string Name { get; set; }
        public bool Insert { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
        public int Top { get; set; }

        public ConfigTable(string name, int top, bool insert, bool update, bool delete)
        {
            this.Name = name;
            this.Top = top;
            this.Insert = insert;
            this.Update = update;
            this.Delete = delete;

        }


        public bool IsValid()
        {

            return !string.IsNullOrEmpty(this.Name);

        }



    }

}
