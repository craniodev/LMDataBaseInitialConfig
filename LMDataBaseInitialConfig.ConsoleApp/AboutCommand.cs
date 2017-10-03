using System;
using System.Collections.Generic;
using System.Text;

namespace LMDataBaseInitialConfig.ConsoleApp
{
    public class AboutCommand : ICommand
    {
        public bool Execute()
        {

            Console.WriteLine(getAbout());


            return false;
        }

        private string getAbout()
        {

            return @"
===============================
== LM DataBase Initial Config==
===============================
";



        }



    }
}
