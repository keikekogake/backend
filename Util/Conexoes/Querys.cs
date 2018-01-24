using System;
using MySql.Data.MySqlClient;

namespace Conexoes {
    public class Querys : AcessaBD {

        public void Insert (string query) {

            //open connection
            if (AbrirConexao () == true) {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand (query, connection);

                try {
                    cmd.ExecuteNonQuery ();
                } catch (Exception) {

                } finally {
                    //close connection
                    AbrirConexao ();
                }
            }
        }

        public void Update (string query) {

            //open connection
            if (AbrirConexao () == true) {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand (query, connection);

                try {
                    cmd.ExecuteNonQuery ();
                } catch (Exception) {

                } finally {
                    //close connection
                    AbrirConexao ();
                }
            }
        }

        public void Delete (string query) {

            if (AbrirConexao () == true) {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand (query, connection);

                try {
                    cmd.ExecuteNonQuery ();
                } catch (Exception) {

                } finally {
                    //close connection
                    AbrirConexao ();
                }

            }
        }

        public string Consulta (string query) {
            string rs = "";
            //open connection
            if (AbrirConexao () == true) {
                //Cria o comando recebendo a query e a conexão do banco.
                MySqlCommand cmd = new MySqlCommand (query, connection);

                //Executa a query
                try {
                    rs = cmd.ExecuteReader ().ToString ();
                } catch (Exception) {

                } finally {
                    FecharConexao ();
                }
            }
            return rs;
        }

    }
}