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
    public class ConfigHelpterTest
    {

        [Fact]
        public void ConfigHelpter_Instance()
        {

            var fileMock = new Mock<IFileHelper>();
            var stringJson = ConfigHelpterMock.get_Json_ConfigHelpter_Load();

            fileMock.Setup(m => m.Reader(It.IsAny<string>())).Returns(stringJson);

            var config = new LMDataBaseInitialConfig.ConsoleApp.Config.ConfigHelpter(fileMock.Object);
            Assert.NotNull(config);
            Assert.NotNull(config.GetTables());

        }


        [Fact]
        public void ConfigHelpter_Save()
        {

            var fileHelper = new Mock<IFileHelper>();
            var config = new LMDataBaseInitialConfig.ConsoleApp.Config.ConfigHelpter(fileHelper.Object);


            config.SetConn("con1", "conncetionstring1");
            config.SetConn("con2", "conncetionstring2");

            config.SetTable(new LMDataBaseInitialConfig.ConsoleApp.Config.ConfigTable("Table1", 1, true, true, true, string.Empty));
            config.SetTable(new LMDataBaseInitialConfig.ConsoleApp.Config.ConfigTable("Table2", 2, true, true, true, string.Empty));
            config.Save();
            fileHelper.Verify(c => c.Save(It.IsAny<string>(), It.Is<string>(i => Helper.CompareOnlyCaracterString(ConfigHelpterMock.get_Json_ConfigHelpter_Save(), (i)))), Times.AtLeastOnce(), "Json was not saved as should");

        }

        [Fact]
        public void ConfigHelpter_Load()
        {




            var fileHelper = new Mock<IFileHelper>();
            fileHelper.Setup(m => m.Reader(It.IsAny<string>())).Returns(ConfigHelpterMock.get_Json_ConfigHelpter_Load());
            fileHelper.Setup(m => m.Exists(It.IsAny<string>())).Returns(true);

            var config = new LMDataBaseInitialConfig.ConsoleApp.Config.ConfigHelpter(fileHelper.Object);
            config.Save();

            fileHelper.Verify(c => c.Save(It.IsAny<string>(), It.Is<string>(i => Helper.CompareOnlyCaracterString(ConfigHelpterMock.get_Json_ConfigHelpter_Load(), (i)))), Times.Once(), "Json was not saved as should");

        }


    }
}
