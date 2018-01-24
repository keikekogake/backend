using System;
using MySql.Data.MySqlClient;

namespace Conexoes {
    public class AcessaBD {
        public MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        protected bool AbrirConexao () {
            server = "";
            database = "";
            uid = "";
            password = "";
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection (connectionString);
            try {
                connection.Open ();
                return true;
            } catch (MySqlException) {
                return false;
            }
        }

        protected bool FecharConexao () {
            try {
                connection.Close ();
                return true;
            } catch (MySqlException) {
                return false;
            }
        }
    }
}