using System;
using System.Collections.Generic;
using System.Text;

namespace LMDataBaseInitialConfig.ConsoleApp.Config
{
    public class ConfigTable
    {

        public string Name { get; set; }
        public bool Insert { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
        public int Top { get; set; }

        public ConfigTable(string name, bool insert, bool update, bool delete)
        {
            this.Name = name;
            this.Insert = insert;
            this.Update = update;
            this.Delete = delete;

        }






    }

}
