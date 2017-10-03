using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LMDataBaseInitialConfig.ConsoleApp
{
    public static class ParserCommand
    {
        public static ICommand Parse(string commandString)
        {
            // Parse your string and create Command object
            var commandParts = commandString.Split(' ').ToList();
            var commandName = commandParts[0];
            var args = commandParts.Skip(1).ToList(); // the arguments is after the command
            switch (commandName)
            {

                // Create command based on CommandName (and maybe arguments)
                case "exit": return new ExitCommand();
                case "about": return new AboutCommand();
                case "help": return new HelpCommand();
                default: return new DeafultCommand(commandName);

            }
        }
    }
}
