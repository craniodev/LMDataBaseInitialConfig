using System;
using System.Collections.Generic;
using System.Text;

namespace LMDataBaseInitialConfig.ConsoleApp.ConfigHelper
{

    public interface IConfigHelpter
    {

        string GetConn(string key);
        string SetConn(string key);
        void RemoveConn(string key);
        List<string> GetConnKeys();

        string GetTable(string key);
        string SetTable(string key);
        void RemoveTable(string key);
        List<string> GetTableKeys();


    }

}
