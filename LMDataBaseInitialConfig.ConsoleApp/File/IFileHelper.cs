using System;
using System.Collections.Generic;
using System.Text;

namespace LMDataBaseInitialConfig.ConsoleApp.File
{
    public interface IFileHelper
    {

        void Save(string fileName, string body);
        string Reader(string fileName);
        bool Exists(string fileName);

    }


}
