using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace WheaterApp
{
    
    public class dataBase
    {

        public static int apiCallsNumber { get; set; }

        protected SQLiteConnection connection;

        public void setupDatabase()
        {
            string sqlQuery = string.Empty;
            using (connection)
            {
                connection.Open();

                sqlQuery = @"CREATE TABLE IF NOT EXISTS Datalogs (type varchar(10), json varchar(4000), dateTimeAddRegistry varchar(10))";
                new SQLiteCommand(sqlQuery, connection).ExecuteNonQuery();

                sqlQuery = @"CREATE TABLE IF NOT EXISTS errorLogs (errorLocation varchar(10), erroMessage varchar(4000), dateTimeAddRegistry varchar(10))";
                new SQLiteCommand(sqlQuery, connection).ExecuteNonQuery();

                sqlQuery = @"CREATE TABLE IF NOT EXISTS system (type varchar(10), value varchar(255),  UNIQUE(type))";
                new SQLiteCommand(sqlQuery, connection).ExecuteNonQuery();

                sqlQuery = $"INSERT INTO system (type, value) values ('ApiCalls', '0')";
                new SQLiteCommand(sqlQuery, connection).ExecuteNonQuery();

                connection.Close();
            }
        }

        public SQLiteConnection getNewConnection() => new SQLiteConnection("Data Source = database.db");


        public dataBase()
        {
            if (!File.Exists("database.db"))
            {
                connection = getNewConnection();
                setupDatabase();
            }
            else
            {
                connection = getNewConnection();
            }
            getDateOnStartAppRun();
        }


        public void insertDataLogs(string type, string json)
        {
            string sqlQuery = string.Empty;
            connection = getNewConnection();
            using (connection)
            {
                connection.Open();

                sqlQuery = $"INSERT INTO Datalogs (type, json, dateTimeAddRegistry) values ('{type}', '{json}', '{DateTime.Today.ToString("dd/MM/yyyy")}')";
                new SQLiteCommand(sqlQuery, connection).ExecuteNonQuery();

                setApiCallNumbers();
                connection.Close();
            }
        }


        public void insertErrorLogs(string errorLocation, string errorMessage)
        {
            string sqlQuery = string.Empty;
            using (connection)
            {
                connection.Open();

                sqlQuery = $"INSERT INTO errorLogs (errorLocation, erroMessage, dateTimeAddRegistry) values ('{errorLocation}', '{errorMessage}', '{DateTime.Today.ToString("dd/MM/yyyy")}')";
                new SQLiteCommand(sqlQuery, connection).ExecuteNonQuery();

                setApiCallNumbers();
                connection.Close();
            }
        }


        public void setApiCallNumbers()
        {
            var sqlQuery = $"SELECT value FROM system WHERE type = 'ApiCalls'";
            var command = new SQLiteCommand(sqlQuery, connection);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read()) { apiCallsNumber = int.Parse(reader.GetString(0)); }
            }

            sqlQuery = $"UPDATE system SET value = {++apiCallsNumber} WHERE type = 'ApiCalls'";
            new SQLiteCommand(sqlQuery, connection).ExecuteNonQuery();
        }


        public List<dataLogs> getDataLogs()
        {
            string sqlQuery = string.Empty;
            List<dataLogs> list = new List<dataLogs>();
            using (connection)
            {
                connection.Open();

                sqlQuery = $"SELECT type, json, dateTimeAddRegistry FROM Datalogs";
                var command = new SQLiteCommand(sqlQuery, connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new dataLogs { type = reader.GetString(0), json = reader.GetString(1), dateTime = reader.GetString(2) });
                    }
                }
                connection.Close();

                return list;
            }
        }


        public List<errorLogs> getErrorLogs()
        {
            string sqlQuery = string.Empty;
            List<errorLogs> list = new List<errorLogs>();
            using (connection)
            {
                connection.Open();

                sqlQuery = $"SELECT errorLocation, erroMessage, dateTimeAddRegistry FROM errorLogs";
                var command = new SQLiteCommand(sqlQuery, connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new errorLogs { errorLocation = reader.GetString(0), erroMessage = reader.GetString(1), dateTime = reader.GetString(2) });
                    }
                }
                connection.Close();

                return list;
            }
        }


        public void getDateOnStartAppRun()
        {
            string sqlQuery = string.Empty;
            using (connection)
            {
                connection.Open();

                sqlQuery = $"SELECT value FROM system WHERE type = 'ApiCalls'";
                var command = new SQLiteCommand(sqlQuery, connection);
                using (var reader = command.ExecuteReader())
                {
                   
                    while (reader.Read()) { apiCallsNumber = int.Parse(reader.GetString(0)); }
                }

                connection.Close();
            }
        }



    }
}
