using LMDataBaseInitialConfig.ConsoleApp.Config;
using LMDataBaseInitialConfig.ConsoleApp.File;
using LMDataBaseInitialConfig.ConsoleApp.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LMDataBaseInitialConfig.ConsoleApp.Service
{
    public class ScriptConfigGeneratorService : IScriptConfigGeneratorService
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

            var configTable = this.ConfigHelper.GetTable(tableName);
            var table = this.SqlHelper.GetTable(tableName);
            AddTableString(sb, table, configTable);
            return sb.ToString();

        }

        public Dictionary<string, string> Generate()
        {
            var sb = new StringBuilder();

            var ret = new Dictionary<string, string>();
            var tablesConfig = this.ConfigHelper.GetTables();
            foreach (var t in tablesConfig)
            {

                sb.Clear();
                var table = this.SqlHelper.GetTable(t.Name);
                AddTableString(sb, table, t);
                ret.Add(t.Name, sb.ToString());

            }

            return ret;


        }

        private void AddTableString(StringBuilder sb, SqlTable table, ConfigTable configTable)
        {

            var cols = string.Join(", ", (from f in table.Fields select f.Name).ToArray());
            var values = new List<string>();

            foreach (var r in table.Rows)
            {
                values.Clear();

                foreach (var f in table.Fields)
                {
                    var v = r.GetValue(f.Name);
                    if (r.GetValue(f.Name) == null)
                        values.Add("NULL");
                    else
                        switch (f.Type)
                        {
                            case SqlField.SqlFieldType.tdatetime:
                                values.Add(r.GetValue(f.Name).ToString());
                                break;
                            case SqlField.SqlFieldType.tnumber:
                                values.Add(r.GetValue(f.Name).ToString());
                                break;
                            case SqlField.SqlFieldType.tbooelan:
                                values.Add((bool)r.GetValue(f.Name) ? "1" : "0");
                                break;
                            case SqlField.SqlFieldType.tstring:
                                values.Add(string.Concat("'", r.GetValue(f.Name).ToString(), "'"));

                                break;

                        }

                }

                sb.AppendLine($"INSERT INTO {table.Name} ({cols}) VALUES ({string.Join(", ", values)})");

            }

            sb.Remove(sb.Length - 2, 2); // Remove last break line

        }


    }


}
