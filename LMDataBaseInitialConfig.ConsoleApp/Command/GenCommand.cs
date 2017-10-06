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

        public GenCommand(IScriptConfigGeneratorService gen, IFileHelper fileHelper)
        {
            this._gen = gen;
            this._fileHelper = fileHelper;
        }

        public bool Execute()
        {

            var dic = _gen.Generate();
            foreach (var t in dic)
            {
                _fileHelper.Save(string.Format($"{t.Key}.sql"), t.Value);
            }

            return false;
        }










    }
}
