using System;
using System.Collections.Generic;
using System.Text;
using LMDataBaseInitialConfig.ConsoleApp.Config;

namespace LMDataBaseInitialConfig.ConsoleApp
{
    public class ConfigCommand : ICommand
    {
        private IConfigHelpter _configHeler;

        public ConfigCommand(Config.IConfigHelpter config)
        {

            this._configHeler = config;

        }

        public bool Execute(string paran)
        {

            if (paran.IndexOf(@"/all") != -1 || paran.IndexOf(@"/getpath") != -1)
                Getpath();

            if (paran.IndexOf(@"/all") != -1 || paran.IndexOf(@"/getconn") != -1)
                Getconn();

            if (paran.IndexOf(@"/all") != -1 || paran.IndexOf(@"/gettables") != -1)
                GetTables();


            return false;
        }

        private void GetTables()
        {
            Console.WriteLine(string.Empty);
            Console.WriteLine(" Tables");
            foreach (var t in this._configHeler.GetTables())
            {

                Console.WriteLine(string.Concat("       ", t.Name, ": "));
                Console.WriteLine(string.Concat("           ", "Top: ", t.Top));
                Console.WriteLine(string.Concat("           ", "Insert: ", t.Insert));
                Console.WriteLine(string.Concat("           ", "Update: ", t.Update));
                Console.WriteLine(string.Concat("           ", "Delete: ", t.Delete));
            }
        }

        private void Getpath()
        {

            Console.WriteLine(string.Empty);
            Console.WriteLine(" Configuration file path");
            Console.WriteLine(string.Concat("   ", this._configHeler.GetConfigPath()));

        }

        private void Getconn()
        {
            Console.WriteLine(string.Empty);
            Console.WriteLine(" Connections Strings");
            foreach (var c in this._configHeler.GetConnKeys())
            {


                Console.WriteLine(string.Concat("       ", c, ": ", this._configHeler.GetConn(c)));
            }


        }


    }
}
