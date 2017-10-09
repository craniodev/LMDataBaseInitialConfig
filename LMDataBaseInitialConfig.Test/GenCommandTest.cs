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
    public class GenCommandTest
    {

        [Fact]
        public void GenCommand_Execute_noParans()
        {

            var fileHelper = new Mock<IFileHelper>();

            const string tableScriptReturn = @"INSERT INTO Table1 (ID, Name) VALUES (1, 'Item1')
INSERT INTO Table1 (ID, Name) VALUES (2, 'Item2')
INSERT INTO Table1 (ID, Name) VALUES (3, 'Item3')";

            var dic = new Dictionary<string, string>();
            dic.Add("Table1", tableScriptReturn);

            var genMock = new Mock<IScriptConfigGeneratorService>();
            genMock.Setup(m => m.Generate()).Returns(dic);


            var GenCommand = new LMDataBaseInitialConfig.ConsoleApp.GenCommand(genMock.Object, fileHelper.Object);

            GenCommand.Execute();


            fileHelper.Verify(c => c.Save(It.IsAny<string>(), It.IsAny<string>()), Times.Once(), "Method Save from FileHelper was not invoked");
            fileHelper.Verify(c => c.Save(It.Is<string>(i => "Table1.sql".Equals(i)), It.IsAny<string>()), Times.Once(), "FileHelper's Save method was not invoked with parameter fileName as Table1");
            fileHelper.Verify(c => c.Save(It.IsAny<string>(), It.Is<string>(i => tableScriptReturn.Equals(i))), Times.Once(), "FileHelper's Save method was not invoked with expected parameter body value");

        }


    }


}
