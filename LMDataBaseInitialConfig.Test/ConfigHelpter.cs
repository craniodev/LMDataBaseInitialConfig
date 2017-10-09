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
    public class ConfigHelpter
    {

        [Fact]
        public void ConfigHelpter_Instance()
        {

            var config = new LMDataBaseInitialConfig.ConsoleApp.Config.ConfigHelpter();
            Assert.NotNull(config);
            Assert.NotNull(config.GetTables());


        }


        [Fact]
        public void ConfigHelpter_SaveLoadTables()
        {

            var config = new LMDataBaseInitialConfig.ConsoleApp.Config.ConfigHelpter();


            config.SetTable(new LMDataBaseInitialConfig.ConsoleApp.Config.ConfigTable("Table1", 1, true, true, true));
            config.SetTable(new LMDataBaseInitialConfig.ConsoleApp.Config.ConfigTable("Table2", 2, true, true, true));

            var config2 = new LMDataBaseInitialConfig.ConsoleApp.Config.ConfigHelpter();


            Assert.Equal(config.GetTables().Count, config2.GetTables().Count);

            Assert.Equal(config.GetTable("Table1").Top, config2.GetTable("Table1").Top);
            Assert.Equal(config.GetTable("Table1").Update, config2.GetTable("Table1").Update);
            Assert.Equal(config.GetTable("Table1").Insert, config2.GetTable("Table1").Insert);

            Assert.Equal(config.GetTable("Table2").Top, config2.GetTable("Table2").Top);
            Assert.Equal(config.GetTable("Table2").Update, config2.GetTable("Table2").Update);
            Assert.Equal(config.GetTable("Table2").Insert, config2.GetTable("Table2").Insert);




        }

        [Fact]
        public void ConfigHelpter_SaveLoadConnectionString()
        {

            var config = new LMDataBaseInitialConfig.ConsoleApp.Config.ConfigHelpter();


            config.SetConn("con1", "conncetionstring1");
            config.SetConn("con2", "conncetionstring2");
            var config2 = new LMDataBaseInitialConfig.ConsoleApp.Config.ConfigHelpter();


            Assert.Equal(config.GetConnKeys().Count, config2.GetConnKeys().Count);
            Assert.Equal(config.GetConn("con1"), config2.GetConn("con1"));
            Assert.Equal(config.GetConn("con2"), config2.GetConn("con2"));







        }




    }
}
