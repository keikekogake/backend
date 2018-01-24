using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace exemploCrud {
    public class BancoDados {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public bool Adicionar (Categoria cat) {
            bool rs = false;

            try {
                con = new SqlConnection ();
                con.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=Papelaria;User Id=sa;Password=senai@123";
                con.Open ();

                cmd = new SqlCommand ();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Categoria (titulo) values (@titulo)";
                cmd.Parameters.AddWithValue ("@titulo", cat.Titulo);

                int r = cmd.ExecuteNonQuery ();

                if (r > 0) {
                    rs = true;
                }
                cmd.Parameters.Clear ();
            } catch (SqlException se) {
                throw new Exception ("Erro ao tentar cadastrar: " + se.Message);
            } catch (Exception ex) {
                throw new Exception ("Erro inesperado: " + ex.Message);
            } finally {
                con.Close ();
            }

            return rs;
        }
        public bool Atualizar (Categoria cat) {
            bool rs = false;

            try {
                con = new SqlConnection ();
                con.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=Papelaria;User Id=sa;Password=senai@123";
                con.Open ();

                cmd = new SqlCommand ();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Categoria set titulo = @titulo where id_categoria = @idCategoria";
                cmd.Parameters.AddWithValue ("@titulo", cat.Titulo);
                cmd.Parameters.AddWithValue ("@idCategoria", cat.IdCategoria);

                int r = cmd.ExecuteNonQuery ();

                if (r > 0) {
                    rs = true;
                }
                cmd.Parameters.Clear ();
            } catch (SqlException se) {
                throw new Exception ("Erro ao tentar atualizar: " + se.Message);
            } catch (Exception ex) {
                throw new Exception ("Erro inesperado: " + ex.Message);
            } finally {
                con.Close ();
            }

            return rs;
        }
        public bool Apagar (Categoria cat) {
            bool rs = false;

            try {
                con = new SqlConnection ();
                con.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=Papelaria;User Id=sa;Password=senai@123";
                con.Open ();

                cmd = new SqlCommand ();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from Categoria where id_categoria = @idCategoria";
                cmd.Parameters.AddWithValue ("@idCategoria", cat.IdCategoria);

                int r = cmd.ExecuteNonQuery ();

                if (r > 0) {
                    rs = true;
                }
                cmd.Parameters.Clear ();
            } catch (SqlException se) {
                throw new Exception ("Erro ao tentar deletar: " + se.Message);
            } catch (Exception ex) {
                throw new Exception ("Erro inesperado: " + ex.Message);
            } finally {
                con.Close ();
            }
            

            return rs;
        }
        public List<Categoria> Consultar (int id) {
            List<Categoria> lista = new List<Categoria> ();

            try {
                con = new SqlConnection ();
                con.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=Papelaria;User Id=sa;Password=senai@123";
                con.Open ();

                cmd = new SqlCommand ();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select id_categoria, titulo from Categoria where id_categoria = @idCategoria";
                cmd.Parameters.AddWithValue ("@idCategoria", id);

                dr = cmd.ExecuteReader ();

                while (dr.Read ()) {
                    lista.Add (new Categoria {
                        IdCategoria = dr.GetInt32 (0),
                            Titulo = dr.GetString (1)
                    });
                }
                cmd.Parameters.Clear ();
            } catch (SqlException se) {
                throw new Exception ("Erro ao consultar dados: " + se.Message);
            } catch (Exception ex) {
                throw new Exception ("Erro inesperado: " + ex.Message);
            } finally {
                con.Close ();
            }

            return lista;
        }
        public List<Categoria> Consultar (string titulo) {
            List<Categoria> lista = new List<Categoria> ();

            try {
                con = new SqlConnection ();
                con.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=Papelaria;User Id=sa;Password=senai@123";
                con.Open ();

                cmd = new SqlCommand ();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select id_categoria, titulo from Categoria where titulo like @titulo";
                cmd.Parameters.AddWithValue ("@titulo", titulo);

                dr = cmd.ExecuteReader ();

                while (dr.Read ()) {
                    lista.Add (new Categoria {
                        IdCategoria = dr.GetInt32 (0),
                            Titulo = dr.GetString (1)
                    });
                }
                cmd.Parameters.Clear ();
            } catch (SqlException se) {
                throw new Exception ("Erro ao consultar dados: " + se.Message);
            } catch (Exception ex) {
                throw new Exception ("Erro inesperado: " + ex.Message);
            } finally {
                con.Close ();
            }

            return lista;
        }
    }
}