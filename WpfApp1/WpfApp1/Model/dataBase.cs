using System;
using System.Windows;
using Microsoft.Data.Sqlite;


namespace WpfApp1
{
    public class dataBase
    {
        private SqliteConnection connection;

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

                sqlQuery = $"INSERT INTO logs (type, json) values ('{type}', '{json}')";
                new SqliteCommand(sqlQuery, connection).ExecuteNonQuery();

                //sqlQuery = "select * FROM logs";
                //var command = new SqliteCommand(sqlQuery, connection);


                //using (var reader = command.ExecuteReader())
                //{
                //    while (reader.Read())
                //    {
                //        var name = reader.GetString(0);
                //        name = reader.GetString(1);

                //        MessageBox.Show($"Hello, {name}!");
                //    }
                //}

                connection.Close();
            }

        }


        public void setupDatabase()
        {
            string sqlQuery = string.Empty;

            using (connection)
            {

                connection.Open();

                sqlQuery = @"CREATE TABLE IF NOT EXISTS logs (type varchar(10), json varchar(4000))";
                new SqliteCommand(sqlQuery, connection).ExecuteNonQuery();
          
                connection.Close();

            }
        }

   
    }
}
