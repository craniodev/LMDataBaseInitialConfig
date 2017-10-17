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
    public class GenCommandTest
    {

        [Fact]
        public void GenCommand_Execute_noParans()
        {
            var fileCondig = new Mock<IConfigHelpter>();
            var fileHelper = new Mock<IFileHelper>();


            var dic = new Dictionary<string, string>();
            dic.Add("Table1", GenCommandTestMock.get_sql_GenCommand_Execute_noParans_script());

            var genMock = new Mock<IScriptConfigGeneratorService>();
            genMock.Setup(m => m.Generate()).Returns(dic);


            fileCondig.Setup(m => m.GetInitialScriptPath()).Returns(string.Empty);
            fileCondig.Setup(m => m.getDateTimeNow()).Returns(new DateTime(2017, 10, 17, 16, 49, 46));

            var GenCommand = new LMDataBaseInitialConfig.ConsoleApp.GenCommand(genMock.Object, fileHelper.Object, fileCondig.Object);

            GenCommand.Execute(string.Empty);


            fileHelper.Verify(c => c.Save(It.IsAny<string>(), It.IsAny<string>()), Times.Once(), "Method Save from FileHelper was not invoked");
            fileHelper.Verify(c => c.Save(It.Is<string>(i => "Table1.sql".Equals(i)), It.IsAny<string>()), Times.Once(), "FileHelper's Save method was not invoked with parameter fileName as Table1");
            fileHelper.Verify(c => c.Save(It.IsAny<string>(), It.Is<string>(i => Helper.CompareOnlyCaracterString(GenCommandTestMock.get_sql_GenCommand_Execute_noParans_file(), i))), Times.Once(), "FileHelper's Save method was not invoked with expected parameter body value");

        }


    }


}
