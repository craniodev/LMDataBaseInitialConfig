using System;

namespace LMDataBaseInitialConfig.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {


            var exit = false;
            while (exit == false)
            {
                Console.WriteLine();
                Console.WriteLine("Enter command (help to display help): ");
                var command = ParserCommand.Parse(Console.ReadLine());
                exit = command.Execute();
            }



        }
    }
}
