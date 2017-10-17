using System;
using System.Collections.Generic;
using System.Text;

namespace LMDataBaseInitialConfig.ConsoleApp.Sql
{
    public class SqlRow
    {

        private Dictionary<string, IConvertible> cols;

        public SqlRow()
        {
            cols = new Dictionary<string, IConvertible>();
        }

        public IConvertible GetValue(string col)
        {
            cols.TryGetValue(col, out IConvertible v);

            return v;

        }

        public void AddCol(string col, IConvertible value)
        {


            if (cols.ContainsKey(col))
                cols[col] = value;
            else
                cols.Add(col, value);


        }




    }

}
