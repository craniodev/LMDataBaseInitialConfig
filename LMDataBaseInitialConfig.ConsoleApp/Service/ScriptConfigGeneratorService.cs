using LMDataBaseInitialConfig.ConsoleApp.ConfigHelper;
using LMDataBaseInitialConfig.ConsoleApp.FileHelper;
using LMDataBaseInitialConfig.ConsoleApp.SqlHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LMDataBaseInitialConfig.ConsoleApp.Service
{
    public class ScriptConfigGeneratorService
    {
        public ISqlHelper SqlHelper { get; }
        public IConfigHelpter ConfigHelper { get; }
        public IFileHelper FileHelper { get; }

        public ScriptConfigGeneratorService(ISqlHelper sqlHelper, IConfigHelpter configHelper, IFileHelper fileHelper)
        {
            this.SqlHelper = sqlHelper;
            this.ConfigHelper = configHelper;
            this.FileHelper = fileHelper;
        }

        public string Generate(string tableName)
        {

            var sb = new StringBuilder();


            var table = SqlHelper.GetTable(tableName);


            var cols = string.Join(", ", (from f in table.Fields select f.Name).ToArray());
            var values = new List<string>();

            foreach (var r in table.Rows)
            {
                values.Clear();

                foreach (var f in table.Fields)
                {

                    switch (f.Type)
                    {
                        case SqlField.SqlFieldType.tdatetime:
                            values.Add(r.GetValue(f.Name).ToString());
                            break;
                        case SqlField.SqlFieldType.tnumber:
                            values.Add(r.GetValue(f.Name).ToString());
                            break;
                        case SqlField.SqlFieldType.tstring:
                            values.Add(string.Concat("'", r.GetValue(f.Name).ToString(), "'"));
                            break;

                    }

                }

                sb.AppendLine($"INSERT INTO {table.Name} ({cols}) VALUES ({string.Join(", ", values)})");

            }

            sb.Remove(sb.Length - 2,2); // Remove last break line

            return sb.ToString();

        }

        public string Generate()
        {
            return string.Empty;

        }




    }


}
