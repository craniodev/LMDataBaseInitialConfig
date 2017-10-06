using System;
using System.Collections.Generic;
using System.Text;

namespace LMDataBaseInitialConfig.ConsoleApp.Service
{
    public interface IScriptConfigGeneratorService
    {
        string Generate(string tableName);
        Dictionary<string, string> Generate();


    }


}
