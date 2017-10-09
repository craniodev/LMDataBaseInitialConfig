using System;
using System.Collections.Generic;
using System.Text;
using static LMDataBaseInitialConfig.ConsoleApp.Sql.SqlField;

namespace LMDataBaseInitialConfig.ConsoleApp.Sql
{
    public class SqlTable
    {
        public string Name { get; }
        public List<SqlField> Fields { get; }
        public List<SqlRow> Rows { get; }

        public SqlTable(string name)
        {
            this.Name = name;
            Fields = new List<SqlField>();
            Rows = new List<SqlRow>();
        }
        public void AddField(string name, SqlFieldType type)
        {
            Fields.Add(new SqlField(name, type));
        }
        public void AddRowItem(int index, string name, IConvertible value)
        {

            SqlRow row = Rows.Count <= index ? null : Rows[index];

            if(row == null)
            {            
                row = new SqlRow();
                Rows.Add(row);
            }


            row.AddCol(name, value);
            


        }

    }


}
