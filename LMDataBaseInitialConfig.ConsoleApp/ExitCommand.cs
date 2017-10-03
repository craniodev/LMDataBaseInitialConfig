using System;
using System.Collections.Generic;
using System.Text;

namespace LMDataBaseInitialConfig.ConsoleApp
{
    public class ExitCommand : ICommand
    {
        public bool Execute()
        {
            return true;
        }
    }
}
