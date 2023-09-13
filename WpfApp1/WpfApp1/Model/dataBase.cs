using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic;
using WeatherApp.Model;

namespace WpfApp1
{
    public class dataBase
    {
        private SqliteConnection connection;
        public static int apiCallsNumber { get; set; }

        public dataBase() 
        {
            connection = new SqliteConnection("Data Source=database.db");
        }
      
        public void insertLogs(string type, string json)
        {
            string sqlQuery = string.Empty;
            using (connection)
            {
                connection.Open();

                sqlQuery = $"INSERT INTO logs (type, json, dateTimeAddRegistry) values ('{type}', '{json}', '{DateTime.Today.ToString("dd/MM/yyyy")}')";
                new SqliteCommand(sqlQuery, connection).ExecuteNonQuery();

                setApiCallNumbers();
                connection.Close();
            }
        }


        public void setApiCallNumbers()
        {
            var sqlQuery = $"SELECT value FROM system WHERE type = 'ApiCalls'";
            var command = new SqliteCommand(sqlQuery, connection);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read()) { apiCallsNumber = reader.GetInt32(0); }
            }

            sqlQuery = $"UPDATE system SET value = {++apiCallsNumber} WHERE type = 'ApiCalls'";
            new SqliteCommand(sqlQuery, connection).ExecuteNonQuery();
        }


        public List<dataLogs> getDataLogs()
        {
            string sqlQuery = string.Empty;
            List<dataLogs> list = new List<dataLogs>();

            using (connection)
            {
                connection.Open();

                sqlQuery = $"SELECT type, json, dateTimeAddRegistry FROM logs";
                var command = new SqliteCommand(sqlQuery, connection);
         
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new dataLogs {type = reader.GetString(0), json = reader.GetString(1), dateTime = reader.GetString(2)});
                    }
                }
                connection.Close();

                return list;
            }

        }


        public void setupDatabase()
        {
            string sqlQuery = string.Empty;

            using (connection)
            {
                connection.Open();

                sqlQuery = @"CREATE TABLE IF NOT EXISTS logs (type varchar(10), json varchar(4000), dateTimeAddRegistry varchar(10))";
                new SqliteCommand(sqlQuery, connection).ExecuteNonQuery();

                sqlQuery = @"CREATE TABLE IF NOT EXISTS system (type varchar(10), value varchar(255))";
                new SqliteCommand(sqlQuery, connection).ExecuteNonQuery();

                sqlQuery = $"INSERT INTO system (type, value) values ('ApiCalls', 0)";
                new SqliteCommand(sqlQuery, connection).ExecuteNonQuery();

                sqlQuery = $"SELECT value FROM system WHERE type = 'ApiCalls'";
                var command = new SqliteCommand(sqlQuery, connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read()) { apiCallsNumber = reader.GetInt32(0); }
                }

                connection.Close();
            }
        }

   
    }
}
