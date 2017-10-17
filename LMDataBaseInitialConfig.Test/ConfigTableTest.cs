using System;
using Xunit;
using Moq;
using LMDataBaseInitialConfig.ConsoleApp.Sql;
using LMDataBaseInitialConfig.ConsoleApp.File;
using LMDataBaseInitialConfig.ConsoleApp.Config;
using System.Collections.Generic;
using System.IO;
using LMDataBaseInitialConfig.ConsoleApp.Service;


namespace LMDataBaseInitialConfig.Test
{


    public class ConfigTableTest
    {
        [Fact]
        public void ConfigTable_IsValid()
        {

            var inValidTable = new LMDataBaseInitialConfig.ConsoleApp.Config.ConfigTable(string.Empty, 1, true, true, true,string.Empty);
            Assert.False(inValidTable.IsValid());


            var validTable = new LMDataBaseInitialConfig.ConsoleApp.Config.ConfigTable("Table1", 1, true, true, true, string.Empty);
            Assert.True(validTable.IsValid());



        }

    }

}
