using System;
using System.Collections.Generic;
using System.Text;

namespace LMDataBaseInitialConfig.ConsoleApp.Config
{

    public interface IConfigHelpter
    {

        string GetConn(string key);
        string SetConn(string key);
        void RemoveConn(string key);
        List<string> GetConnKeys();

        ConfigTable GetTable(string key);
        string SetTable(ConfigTable table);
        void RemoveTable(string key);
        List<ConfigTable> GetTables();


    }

}
