using LMDataBaseInitialConfig.ConsoleApp.ConfigHelper;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMDataBaseInitialConfig.ConsoleApp
{
    public class GenCommand : ICommand
    {
        private IConfigHelpter _ConfigHelpter;

        public GenCommand(IConfigHelpter configHelpter)
        {

            this._ConfigHelpter = configHelpter;

        }

        public bool Execute()
        {
            throw new NotImplementedException();
        }










    }
}
