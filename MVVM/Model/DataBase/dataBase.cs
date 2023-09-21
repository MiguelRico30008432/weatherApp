using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace WheaterApp
{
    public class dataBase : BaseDataBase
    {
        public static int apiCallsNumber { get; set; }

        public dataBase()
        {
            if (!File.Exists("database.db")) { setupDatabase(); }    
            getDateOnStartAppRun();
        }


        public void insertDataLogs(string type, string json)
        {
            _connection = Connection;
            string sqlQuery = string.Empty;
            using (_connection)
            {
                _connection.Open();

                sqlQuery = $"INSERT INTO Datalogs (type, json, dateTimeAddRegistry) values ('{type}', '{json}', '{DateTime.Today.ToString("dd/MM/yyyy")}')";
                new SQLiteCommand(sqlQuery, _connection).ExecuteNonQuery();

                setApiCallNumbers();
                _connection.Close();
            }
        }


        public void insertErrorLogs(string errorLocation, string errorMessage)
        {
            _connection = Connection;
            string sqlQuery = string.Empty;
            using (_connection)
            {
                _connection.Open();

                sqlQuery = $"INSERT INTO errorLogs (errorLocation, erroMessage, dateTimeAddRegistry) values ('{errorLocation}', '{errorMessage}', '{DateTime.Today.ToString("dd/MM/yyyy")}')";
                new SQLiteCommand(sqlQuery, _connection).ExecuteNonQuery();

                setApiCallNumbers();
                _connection.Close();
            }
        }


        public void setApiCallNumbers()
        {
            var sqlQuery = $"SELECT value FROM system WHERE type = 'ApiCalls'";
            var command = new SQLiteCommand(sqlQuery, _connection);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read()) { apiCallsNumber = int.Parse(reader.GetString(0)); }
            }

            sqlQuery = $"UPDATE system SET value = {++apiCallsNumber} WHERE type = 'ApiCalls'";
            new SQLiteCommand(sqlQuery, _connection).ExecuteNonQuery();
        }


        public List<dataLogs> getDataLogs()
        {
            _connection = Connection;
            string sqlQuery = string.Empty;
            List<dataLogs> list = new List<dataLogs>();
            using (_connection)
            {
                _connection.Open();

                sqlQuery = $"SELECT type, json, dateTimeAddRegistry FROM Datalogs";
                var command = new SQLiteCommand(sqlQuery, _connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new dataLogs { type = reader.GetString(0), json = reader.GetString(1), dateTime = reader.GetString(2) });
                    }
                }
                _connection.Close();

                return list;
            }
        }


        public List<errorLogs> getErrorLogs()
        {
            _connection = Connection;
            string sqlQuery = string.Empty;
            List<errorLogs> list = new List<errorLogs>();
            using (_connection)
            {
                _connection.Open();

                sqlQuery = $"SELECT errorLocation, erroMessage, dateTimeAddRegistry FROM errorLogs";
                var command = new SQLiteCommand(sqlQuery, _connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new errorLogs { errorLocation = reader.GetString(0), erroMessage = reader.GetString(1), dateTime = reader.GetString(2) });
                    }
                }
                _connection.Close();

                return list;
            }
        }


        public void getDateOnStartAppRun()
        {
            _connection = Connection;
            string sqlQuery = string.Empty;
            using (_connection)
            {
                _connection.Open();

                sqlQuery = $"SELECT value FROM system WHERE type = 'ApiCalls'";
                var command = new SQLiteCommand(sqlQuery, _connection);
                using (var reader = command.ExecuteReader())
                {
                   
                    while (reader.Read()) { apiCallsNumber = int.Parse(reader.GetString(0)); }
                }

                _connection.Close();
            }
        }
    }
}
