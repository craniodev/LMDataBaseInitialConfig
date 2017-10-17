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

namespace LMDataBaseInitialConfig.Test.Mock
{
    public static class GenCommandTestMock
    {

        public static string get_sql_GenCommand_Execute_noParans_script()
        {

            return MockHelper.GetSqlMock("GenCommand_Execute_noParans_script");

        }



        public static string get_sql_GenCommand_Execute_noParans_file()
        {

            return MockHelper.GetSqlMock("GenCommand_Execute_noParans_file");

        }



    }


}
