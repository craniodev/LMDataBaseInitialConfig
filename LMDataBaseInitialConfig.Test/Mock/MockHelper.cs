using System;
using Xunit;
using Moq;
using LMDataBaseInitialConfig.ConsoleApp.Sql;
using LMDataBaseInitialConfig.ConsoleApp.File;
using LMDataBaseInitialConfig.ConsoleApp.Config;
using System.Collections.Generic;
using System.IO;
using LMDataBaseInitialConfig.ConsoleApp.Service;
using LMDataBaseInitialConfig.Test.Mock;

namespace LMDataBaseInitialConfig.Test
{
    public static class MockHelper
    {

        public static string GetJsonMockDirectory()
        {

            const string TEST_NAME = "LMDataBaseInitialConfig.Test";
            var p = Directory.GetCurrentDirectory();
            p = p.Remove(p.IndexOf(TEST_NAME) + TEST_NAME.Length);
            p = System.IO.Path.Combine(p, "Mock\\jsons");

            return p;

        }

        public static string GetSqlMockDirectory()
        {

            const string TEST_NAME = "LMDataBaseInitialConfig.Test";
            var p = Directory.GetCurrentDirectory();
            p = p.Remove(p.IndexOf(TEST_NAME) + TEST_NAME.Length);
            p = System.IO.Path.Combine(p, "Mock\\sql");

            return p;

        }

        public static string GetJsonMock(string name)
        {

            return File.ReadAllText(System.IO.Path.Combine(GetJsonMockDirectory(), $"{name}.json"));

        }
        public static string GetSqlMock(string name)
        {

            return File.ReadAllText(System.IO.Path.Combine(GetSqlMockDirectory(), $"{name}.sql"));

        }



    }
}
