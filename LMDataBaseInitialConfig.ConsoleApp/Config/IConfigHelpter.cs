using System;
using System.Collections.Generic;
using System.Text;

namespace LMDataBaseInitialConfig.ConsoleApp.Config
{

    public interface IConfigHelpter
    {
        DateTime getDateTimeNow();
        string GetInitialScriptPath();
        string GetConfigPath();
        string GetConn(string key);
        void SetConn(string key, string value);
        void RemoveConn(string key);
        List<string> GetConnKeys();

        ConfigTable GetTable(string key);
        void SetTable(ConfigTable table);
        void RemoveTable(string key);
        List<ConfigTable> GetTables();

        string Version { get; }

        void Load();
        void Save();


    }

}
