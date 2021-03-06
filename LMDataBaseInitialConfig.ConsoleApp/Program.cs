﻿using LMDataBaseInitialConfig.ConsoleApp.Service;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace LMDataBaseInitialConfig.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var myInject = Injection.Injector.Instance();
            var exit = false;
            while (exit == false)
            {

  

                Console.WriteLine();
                Console.WriteLine("Enter command (help to display help): ");
                var line = Console.ReadLine();
                var command = ParserCommand.Parse(line, myInject);
                exit = command.Execute(line);

            }



        }




    }
}
