using Dapper;
using System;
using System.Data;
using System.Data.SQLite;

namespace Api.Repository.Helper
{
    public static class QueryHelper
    {
        public static void ExecuteQuery(this SQLiteConnection connection, string query, object parameter = null)
        {
            if (connection == null)
                throw new NullReferenceException("Please provide a connection");

            if (connection.State != ConnectionState.Open)
                connection.Open();

            connection.Execute(query, parameter);
        }
    }
}