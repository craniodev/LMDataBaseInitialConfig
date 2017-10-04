using System;
using System.Collections.Generic;
using System.Text;

namespace LMDataBaseInitialConfig.ConsoleApp.SqlHelper
{
    public class SqlField
    {
        public enum SqlFieldType
        {
            tstring,
            tnumber,
            tdatetime
        }

        public SqlField(string name, SqlFieldType type)
        {
            this.Name = name;
            this.Type = type;
        }

        public string Name { get; }
        public SqlFieldType Type { get; }

    }
}
