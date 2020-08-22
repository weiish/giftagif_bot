using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifBotManager
{
    class DBConnection
    {
        private DBConnection() { }

        private string databaseName = string.Empty;
        public string DatabaseName {
            get { return databaseName; }
            set { databaseName = value; }
        }

        public string Username { private get; set; }
        public string Password { private get; set; }

        private MySqlConnection connection = null;
        public MySqlConnection Connection {
            get { return connection; }
        }

        private static DBConnection _instance = null;
        public static DBConnection Instance() {
            if (_instance == null)
                _instance = new DBConnection();
            return _instance;
        }

        public bool IsConnect() {
            if (Connection == null) {
                if (String.IsNullOrEmpty(databaseName))
                    return false;
                string connstring = string.Format("Server=localhost; database={0}; UID={1}; password={2}", databaseName, Username, Password);
                try {
                    connection = new MySqlConnection(connstring);
                    connection.Open();
                    Console.WriteLine("Connected to database " + databaseName);
                } catch (Exception e) {
                    Console.WriteLine("Error connecting to database " + databaseName + " " + e.Message);
                    return false;
                }
            }
            return true;
        }

        public void Close() {
            connection.Close();
            connection = null;
        }
    }
}
