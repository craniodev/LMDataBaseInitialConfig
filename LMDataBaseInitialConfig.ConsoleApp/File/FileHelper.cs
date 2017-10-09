using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LMDataBaseInitialConfig.ConsoleApp.File
{
    public class FileHelper : IFileHelper
    {
        public void Save(string fileName, string body)
        {
            using (StreamWriter outputFile = new StreamWriter(fileName, false))
            {

                outputFile.Write(body);
            }

        }

        public string Reader(string fileName)
        {

            string ret = string.Empty;
            using (StreamReader r = new StreamReader(fileName))
            {
                ret = r.ReadToEnd();

            }

            return ret;
        }

        public bool Exists(string fileName)
        {
            return System.IO.File.Exists(fileName);
        }
    }


}
