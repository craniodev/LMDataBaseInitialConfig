using System;
using Xunit;
using Moq;
using LMDataBaseInitialConfig.ConsoleApp.SqlHelper;
using LMDataBaseInitialConfig.ConsoleApp.FileHelper;
using LMDataBaseInitialConfig.ConsoleApp.ConfigHelper;

namespace LMDataBaseInitialConfig.Test
{
    public class ScriptConfigGeneratorService
    {
        [Fact]
        public void ScriptConfigGeneratorService_Generate()
        {


            var sqlTable = new SqlTable("Table1");
            sqlTable.AddField("ID", SqlField.SqlFieldType.tnumber);
            sqlTable.AddField("Name", SqlField.SqlFieldType.tstring);

            sqlTable.AddRowItem(0, "ID", 1);
            sqlTable.AddRowItem(0, "Name", "Item1");

            sqlTable.AddRowItem(1, "ID", 2);
            sqlTable.AddRowItem(1, "Name", "Item2");

            sqlTable.AddRowItem(2, "ID", 3);
            sqlTable.AddRowItem(2, "Name", "Item3");


            var sqlHelperMoq = new Mock<ISqlHelper>();
            sqlHelperMoq.Setup(r => r.GetTable(sqlTable.Name)).Returns(sqlTable);



            var configHelpter = new Mock<IConfigHelpter>();
            var fileHelper = new Mock<IFileHelper>();

            var Generator = new LMDataBaseInitialConfig.ConsoleApp.Service.ScriptConfigGeneratorService(sqlHelperMoq.Object, configHelpter.Object, fileHelper.Object);



            const string tableScriptReturn = @"INSERT INTO Table1 (ID, Name) VALUES (1, 'Item1')
INSERT INTO Table1 (ID, Name) VALUES (2, 'Item2')
INSERT INTO Table1 (ID, Name) VALUES (3, 'Item3')";



            var tableScript = Generator.Generate(sqlTable.Name);

            Assert.Equal(tableScript, tableScriptReturn);


        }
    }
}
