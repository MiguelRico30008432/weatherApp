using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheaterApp
{
    public abstract class BaseDataBase
    {
        private string dabaBaseName = "database";
        protected SQLiteConnection _connection;
        public SQLiteConnection Connection
        {
            get { return new SQLiteConnection($"Data Source = {dabaBaseName}.db"); }
            set { }
        }

        public void setupDatabase()
        {
            _connection = Connection;
            string sqlQuery = string.Empty;
            using (_connection)
            {
                _connection.Open();

                sqlQuery = @"CREATE TABLE IF NOT EXISTS Datalogs (type varchar(10), json varchar(4000), dateTimeAddRegistry varchar(10))";
                new SQLiteCommand(sqlQuery, _connection).ExecuteNonQuery();

                sqlQuery = @"CREATE TABLE IF NOT EXISTS errorLogs (errorLocation varchar(10), erroMessage varchar(4000), dateTimeAddRegistry varchar(10))";
                new SQLiteCommand(sqlQuery, _connection).ExecuteNonQuery();

                sqlQuery = @"CREATE TABLE IF NOT EXISTS system (type varchar(10), value varchar(255),  UNIQUE(type))";
                new SQLiteCommand(sqlQuery, _connection).ExecuteNonQuery();

                sqlQuery = $"INSERT INTO system (type, value) values ('ApiCalls', '0')";
                new SQLiteCommand(sqlQuery, _connection).ExecuteNonQuery();

                _connection.Close();
            }
        }

    }
}
