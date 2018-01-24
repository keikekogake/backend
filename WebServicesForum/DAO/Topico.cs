using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebServicesForum.Models;

namespace WebServicesForum.DAO {
    public class Topico : AcessaBD, IAcoes {

        public bool Atualizar () {
            return false;
        }
        public bool Cadastrar () {
            return false;
        }
        public bool Deletar () {
            return false;
        }

        public bool Cadastrar (TopicoModel topico) {
            bool res = false;
            try {
                if (Open ()) {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_cadastrar_topico";
                    cmd.Parameters.Add (new SqlParameter ("@titulo", topico.Titulo));
                    cmd.Parameters.Add (new SqlParameter ("@descricao", topico.Descricao));

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

        public List<TopicoModel> Listar () {
            List<TopicoModel> list = new List<TopicoModel> ();
            try {
                if (Open ()) {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from topicoforum;";
                    dr = cmd.ExecuteReader ();

                    while (dr.Read ()) {
                        list.Add (new TopicoModel {
                            Id = dr.GetInt32 (0),
                                Titulo = dr.GetString (1),
                                Descricao = dr.GetString (2),
                                DataCadastro = dr.GetDateTime (3)
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

        public bool Atualizar (TopicoModel topico) {
            bool retorno = false;
            try {
                if (Open ()) {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_atualizar_topico";
                    cmd.Parameters.Add (new SqlParameter ("@id", topico.Id));
                    cmd.Parameters.Add (new SqlParameter ("@titulo", topico.Titulo));
                    cmd.Parameters.Add (new SqlParameter ("@descricao", topico.Descricao));

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

        public bool Deletar (TopicoModel topico) {
            bool retorno = false;
            try {
                if (Open ()) {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_deletar_topico";
                    cmd.Parameters.Add (new SqlParameter ("@id", topico.Id));

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