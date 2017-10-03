using System;
using System.Collections.Generic;
using System.Text;

namespace LMDataBaseInitialConfig.ConsoleApp
{
    public class HelpCommand : ICommand
    {
        public bool Execute()
        {

            Console.WriteLine(getAbout());


            return false;
        }

        private string getAbout()
        {

            return @"Not implemented";



        }

    }
}
