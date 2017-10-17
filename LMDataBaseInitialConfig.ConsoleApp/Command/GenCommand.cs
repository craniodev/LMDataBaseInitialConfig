using LMDataBaseInitialConfig.ConsoleApp.Config;
using LMDataBaseInitialConfig.ConsoleApp.File;
using LMDataBaseInitialConfig.ConsoleApp.Service;
using LMDataBaseInitialConfig.ConsoleApp.Sql;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMDataBaseInitialConfig.ConsoleApp
{
    public class GenCommand : ICommand
    {
        private IScriptConfigGeneratorService _gen;
        private IFileHelper _fileHelper;
        private IConfigHelpter _configHelper;

        public GenCommand(IScriptConfigGeneratorService gen, IFileHelper fileHelper, Config.IConfigHelpter configHelper)
        {
            this._gen = gen;
            this._fileHelper = fileHelper;
            this._configHelper = configHelper;
        }

        public bool Execute(string paran)
        {
            var sb = new StringBuilder();
            var dic = _gen.Generate();
            foreach (var t in dic)
            {
                sb.Clear();
                sb.AppendLine("-- ================================================");
                sb.AppendLine("-- Generated from LMDataBaseInitialConfig:");
                sb.AppendLine("-- https://github.com/LogicalMinds/LMDataBaseInitialConfig");
                sb.AppendLine($"-- Version: {this._configHelper.Version}  Script Date: {DateTime.Now.ToString()}");
                sb.AppendLine("-- ================================================");
                sb.AppendLine(string.Empty);
                sb.Append(t.Value);

                var p = System.IO.Path.Combine(this._configHelper.GetInitialScriptPath(), string.Format($"{t.Key}.sql"));

                _fileHelper.Save(p, sb.ToString());
            }

            return false;
        }










    }
}
