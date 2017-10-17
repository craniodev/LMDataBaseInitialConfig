using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace LMDataBaseInitialConfig.ConsoleApp.Sql
{
    public class SqlHelper : ISqlHelper
    {


        private const string SQL_GET_TABLE_INFO = @"SELECT *
                                                    FROM INFORMATION_SCHEMA.COLUMNS
                                                    WHERE TABLE_NAME = @table";

        private const string SQL_GET_TABLE_ROWNS = @"SELECT TOP {0} *
                                                    FROM {1}";



        private string connectionString;
        public SqlHelper()
        {
            connectionString = @"Server=localhost;Database=RepomUsuario;Trusted_Connection=true;";
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }


        public SqlTable GetTable(string name)
        {


            var myTable = new SqlTable(name);
            var retorno = Connection.Query<INFORMATION_SCHEMA_COLUMNS>(SQL_GET_TABLE_INFO, new { table = name });
            foreach (var r in retorno)
            {
                myTable.AddField(r.COLUMN_NAME, SqlTypeToSqlFieldType(r.DATA_TYPE));
            }


            var index = 0;
            var rowns = Connection.Query(string.Format(SQL_GET_TABLE_ROWNS, 100, name));
            foreach (IDictionary<string, object> r in rowns)
            {

                foreach (var f in myTable.Fields)
                {
                    myTable.AddRowItem(index, f.Name, (IConvertible)r[f.Name]);
                }



                index++;
            }

            return myTable;

        }


        private SqlField.SqlFieldType SqlTypeToSqlFieldType(string sqlType)
        {

            switch (sqlType)
            {
                case "int":
                case "number":
                case "decimal":
                    return SqlField.SqlFieldType.tnumber;
                case "varchar":
                case "char":
                    return SqlField.SqlFieldType.tstring;
                case "date":
                case "datetime":
                    return SqlField.SqlFieldType.tdatetime;
                case "bit":
                    return SqlField.SqlFieldType.tbooelan;
                default:
                    throw new NotImplementedException($"SQL type {sqlType} not implemented.");


            }


        }


        private class INFORMATION_SCHEMA_COLUMNS
        {
            public string COLUMN_NAME { get; set; }
            public string DATA_TYPE { get; set; }
        }


    }


}
