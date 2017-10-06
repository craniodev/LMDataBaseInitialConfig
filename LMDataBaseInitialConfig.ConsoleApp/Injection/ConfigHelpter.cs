using System.Collections.Generic;
using LMDataBaseInitialConfig.ConsoleApp.Config;

namespace LMDataBaseInitialConfig.ConsoleApp.Injection
{
    public class ConfigHelpter : IConfigHelpter
    {
        public string GetConn(string key)
        {
            throw new System.NotImplementedException();
        }

        public List<string> GetConnKeys()
        {
            throw new System.NotImplementedException();
        }

        public ConfigTable GetTable(string key)
        {
            throw new System.NotImplementedException();
        }

        public List<ConfigTable> GetTables()
        {
            throw new System.NotImplementedException();
        }

        public void RemoveConn(string key)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveTable(string key)
        {
            throw new System.NotImplementedException();
        }

        public string SetConn(string key)
        {
            throw new System.NotImplementedException();
        }

        public string SetTable(ConfigTable table)
        {
            throw new System.NotImplementedException();
        }
    }
}