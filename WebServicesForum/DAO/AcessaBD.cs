using System;
using System.Data.SqlClient;
using Microsoft.Data;

namespace WebServicesForum.DAO {
    public abstract class AcessaBD {

        /// <summary>
        /// Objeto utilizado para construir a string de conexão com o banco de dados
        /// </summary>
        protected SqlConnectionStringBuilder strCon;
        /// <summary>
        /// Objeto utilizado para criar a conexão com o banco de dados
        /// </summary>
        protected SqlConnection con;
        /// <summary>
        /// Objeto utilizado para executar os comando SQL no banco de dados;
        /// </summary>
        protected SqlCommand cmd = new SqlCommand ();
        /// <summary>
        /// Objeto utilizado para guardar os retornos do select realizados no banco de dados
        /// </summary>
        protected SqlDataReader dr;

        protected AcessaBD () {
            con = new SqlConnection ();
            strCon = new SqlConnectionStringBuilder ();

            strCon.DataSource = @".\sqlexpress";
            strCon.InitialCatalog = "BancoForum";
            strCon.UserID = "sa";
            strCon.Password = "senai@123";

            con.ConnectionString = strCon.ConnectionString;
            // con.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=BancoForum;User Id=sa;Password=senai@123";
        }

        protected bool Open () {
            try {
                con.Open ();
                return true;
            } catch (SqlException se) {
                throw new Exception (se.Message);
            } catch (Exception ex) {
                throw new Exception (ex.Message);
            }
        }
        protected bool Close () {
            try {
                con.Close ();
                return true;
            } catch (SqlException se) {
                throw new Exception (se.Message);
            } catch (Exception ex) {
                throw new Exception (ex.Message);
            }
        }
    }
}