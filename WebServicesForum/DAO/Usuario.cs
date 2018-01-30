using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebServicesForum.Models;

namespace WebServicesForum.DAO {
    public class Usuario : AcessaBD, IAcoes {

        public bool Atualizar () {
            return false;
        }
        public bool Cadastrar () {
            return false;
        }
        public bool Deletar () {
            return false;
        }
        public bool Atualizar (UsuarioModel usuario) {
            bool retorno = false;
            try {
                if (Open ()) {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_atualizar_usuario";
                    cmd.Parameters.Add (new SqlParameter ("@id", usuario.Id));
                    cmd.Parameters.Add (new SqlParameter ("@nome", usuario.Nome));
                    cmd.Parameters.Add (new SqlParameter ("@login", usuario.Login));
                    cmd.Parameters.Add (new SqlParameter ("@senha", usuario.Senha));

                    int i = cmd.ExecuteNonQuery ();
                    if (i > 0) {
                        retorno = true;
                    }
                    cmd.Parameters.Clear ();
                }
                return retorno;
            } catch (SqlException se) {
                throw new Exception (se.Message);
            } catch (Exception ex) {
                throw new Exception (ex.Message);
            } finally {
                Close ();
            }
        }

        public bool Cadastrar (UsuarioModel usuario) {
            bool retorno = false;

            try {
                if (Open ()) {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_cadastrar_usuario";
                    cmd.Parameters.Add (new SqlParameter ("@nome", usuario.Nome));
                    cmd.Parameters.Add (new SqlParameter ("@login", usuario.Login));
                    cmd.Parameters.Add (new SqlParameter ("@senha", usuario.Senha));

                    int i = cmd.ExecuteNonQuery ();
                    retorno = true;
                    cmd.Parameters.Clear ();
                }
                return retorno;
            } catch (SqlException se) {
                throw new Exception (se.Message);
            } catch (Exception ex) {
                throw new Exception (ex.Message);
            } finally {
                Close ();
            }
        }

        public bool Logar (UsuarioModel usuario) {
            bool retorno = false;
            try {
                if (Open ()) {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT count(*) FROM usuario where login = @login and senha = @senha;";
                    cmd.Parameters.AddWithValue ("@login", usuario.Login);
                    cmd.Parameters.AddWithValue ("@senha", usuario.Senha);
                    dr = cmd.ExecuteReader ();

                    while (dr.Read ()) {
                        retorno = true;
                    }
                    cmd.Parameters.Clear ();
                }
                return retorno;
            } catch (SqlException se) {
                throw new Exception (se.Message);
            } catch (Exception ex) {
                throw new Exception (ex.Message);
            } finally {
                Close ();
            }
        }

        public List<UsuarioModel> BuscarDados () {
            List<UsuarioModel> list = new List<UsuarioModel> ();

            try {
                if (Open ()) {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM usuario";
                    dr = cmd.ExecuteReader ();

                    while (dr.Read ()) {
                        list.Add (new UsuarioModel {
                            Id = dr.GetInt32 (0),
                                Nome = dr.GetString (1),
                                Login = dr.GetString (2),
                                Senha = dr.GetString (3),
                                DataCadastro = dr.GetDateTime (4)
                        });
                    }
                }
                return list;
            } catch (SqlException se) {
                throw new Exception (se.Message);
            } catch (Exception ex) {
                throw new Exception (ex.Message);
            } finally {
                Close ();
            }
        }

        public bool Deletar (UsuarioModel usuario) {
            bool retorno = false;
            try {
                if (Open ()) {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_deletar_usuario";
                    cmd.Parameters.Add (new SqlParameter ("@id", usuario.Id));

                    int i = cmd.ExecuteNonQuery ();
                    if (i > 0) {
                        retorno = true;
                    }
                    cmd.Parameters.Clear ();
                }
                return retorno;
            } catch (SqlException se) {
                throw new Exception (se.Message);
            } catch (Exception ex) {
                throw new Exception (ex.Message);
            } finally {
                Close ();
            }
        }
    }
}