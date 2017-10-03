using System;
using System.Collections.Generic;
using System.Text;

namespace LMDataBaseInitialConfig.ConsoleApp
{
    public class DeafultCommand : ICommand
    {
        private string command;

        public DeafultCommand(string command)
        {
            this.command = command;
        }

        public bool Execute()
        {
            Console.WriteLine("'{0}' is not recognized as an internal command.", command);
            return false;
        }






    }
}
