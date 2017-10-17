using System;
using System.Collections.Generic;
using System.Text;

namespace LMDataBaseInitialConfig.ConsoleApp
{
    public interface ICommand
    {
        bool Execute(string parans);
    }
}
