using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebServicesForum.Models;

namespace WebServicesForum.DAO {
    public class Postagem : AcessaBD, IAcoes {
        public bool Atualizar () {
            return false;
        }

        public bool Cadastrar () {
            return false;
        }

        public bool Deletar () {
            return false;
        }

        public bool Cadastrar (PostagemModel postagem) {
            bool res = false;
            try {
                if (Open ()) {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_cadastrar_postagem";
                    cmd.Parameters.Add (new SqlParameter ("@idtopico", postagem.IdTopico));
                    cmd.Parameters.Add (new SqlParameter ("@idusuario", postagem.IdUsuario));
                    cmd.Parameters.Add (new SqlParameter ("@mensagem", postagem.Mensagem));

                    int i = cmd.ExecuteNonQuery ();
                    if (i > 0) {
                        res = true;
                    }
                    cmd.Parameters.Clear ();
                }
                return res;
            } catch (SqlException se) {
                throw new Exception (se.Message);
            } catch (Exception ex) {
                throw new Exception (ex.Message);
            } finally {
                Close ();
            }
        }

        public List<PostagemModel> Listar () {
            List<PostagemModel> list = new List<PostagemModel> ();
            try {
                if (Open ()) {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from postagem;";
                    dr = cmd.ExecuteReader ();

                    while (dr.Read ()) {
                        list.Add (new PostagemModel {
                            Id = dr.GetInt32 (0),
                                IdTopico = dr.GetInt32 (1),
                                IdUsuario = dr.GetInt32 (2),
                                Mensagem = dr.GetString (3),
                                DataPublicacao = dr.GetDateTime (4)
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

        public bool Atualizar (PostagemModel postagem) {
            bool retorno = false;
            try {
                if (Open ()) {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_atualizar_postagem";
                    cmd.Parameters.Add (new SqlParameter ("@id", postagem.Id));
                    cmd.Parameters.Add (new SqlParameter ("@mensagem", postagem.Mensagem));

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

        public bool Deletar (PostagemModel postagem) {
            bool retorno = false;
            try {
                if (Open ()) {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_deletar_postagem";
                    cmd.Parameters.Add (new SqlParameter ("@id", postagem.Id));

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