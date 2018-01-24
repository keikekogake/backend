using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WebServicesCidades.Models {
    public class DAOCidades {
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader rd = null;
        string strCon = @"Data Source = .\SQLEXPRESS;Initial Catalog = ProjetoCidades; user id = sa; password = senai@123";
        public List<Cidades> Listar () {
            List<Cidades> list = new List<Cidades> ();
            try {
                con = new SqlConnection ();
                con.ConnectionString = strCon;
                con.Open ();

                cmd = new SqlCommand ();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Cidades";

                rd = cmd.ExecuteReader ();

                while (rd.Read ()) {
                    list.Add (new Cidades () {
                        Id = rd.GetInt32 (0),
                            Cidade = rd.GetString (1),
                            Estado = rd.GetString (2),
                            Habitantes = rd.GetInt32 (3)
                    });
                }
                return list;
            } catch (SqlException se) {
                throw new Exception (se.Message);
            } catch (Exception ex) {
                throw new Exception (ex.Message);
            } finally {
                con.Close();
            }
        }

        public bool Cadastrar (Cidades cidades) {
            bool retorno = false;
            try {
                con = new SqlConnection (strCon);
                con.Open ();

                cmd = new SqlCommand ();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Cidades (nome, estado, habitantes) values (@nome, @estado, @habitantes);";
                cmd.Parameters.AddWithValue ("@nome", cidades.Cidade);
                cmd.Parameters.AddWithValue ("@estado", cidades.Estado);
                cmd.Parameters.AddWithValue ("@habitantes", cidades.Habitantes);

                int i = cmd.ExecuteNonQuery ();

                if (i > 0) {
                    retorno = true;
                }
                cmd.Parameters.Clear ();
                return retorno;
            } catch (SqlException se) {
                throw new Exception (se.Message);
            } catch (Exception ex) {
                throw new Exception (ex.Message);
            } finally {
                con.Close ();
            }
        }

        public bool Atualizar (Cidades cidades) {
            bool retorno = false;
            try {
                con = new SqlConnection (strCon);
                con.Open ();

                cmd = new SqlCommand ();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Cidades set nome = @nome, estado = @estado, habitantes = @habitantes where id = @id;";
                cmd.Parameters.AddWithValue ("@nome", cidades.Cidade);
                cmd.Parameters.AddWithValue ("@estado", cidades.Estado);
                cmd.Parameters.AddWithValue ("@habitantes", cidades.Habitantes);
                cmd.Parameters.AddWithValue ("@id", cidades.Id);

                int i = cmd.ExecuteNonQuery ();

                if (i > 0) {
                    retorno = true;
                }
                cmd.Parameters.Clear ();
                return retorno;
            } catch (SqlException se) {
                throw new Exception (se.Message);
            } catch (Exception ex) {
                throw new Exception (ex.Message);
            } finally {
                con.Close ();
            }
        }
        public bool Deletar (Cidades cidades) {
            bool retorno = false;
            try {
                con = new SqlConnection (strCon);
                con.Open ();

                cmd = new SqlCommand ();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from Cidades where id = @id";
                cmd.Parameters.AddWithValue ("@id", cidades.Id);

                int i = cmd.ExecuteNonQuery ();

                if (i > 0) {
                    retorno = true;
                }
                cmd.Parameters.Clear ();
                return retorno;
            } catch (SqlException se) {
                throw new Exception (se.Message);
            } catch (Exception ex) {
                throw new Exception (ex.Message);
            } finally {
                con.Close ();
            }
        }
    }
}