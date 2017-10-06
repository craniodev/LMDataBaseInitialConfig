using LMDataBaseInitialConfig.ConsoleApp.Injection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LMDataBaseInitialConfig.ConsoleApp
{
    public static class ParserCommand
    {

        public static ICommand Parse(string commandString, IInjector injector)
        {

            var commandParts = commandString.Split(' ').ToList();
            var commandName = commandParts[0];
            var args = commandParts.Skip(1).ToList(); // the arguments is after the command
            switch (commandName)
            {

                // Create command based on CommandName (and maybe arguments)
                case "exit": return injector.GetService<ExitCommand>();
                case "about": return injector.GetService<AboutCommand>();
                case "help": return injector.GetService<HelpCommand>();
                case "gen": return injector.GetService<GenCommand>();
                default: return new DeafultCommand(commandName);

            }
        }
    }
}
