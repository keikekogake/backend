using System;
using System.Data;
using System.Data.SqlClient;

namespace exemploCrud {
    public class RepCliente {
        AcessaBD bd = new AcessaBD ();
        SqlCommand cmd;
        SqlDataReader dr;
        public bool Adicionar (Cliente cliente) {
            bool retorno = false;

            try {
                bd.Open ();
                cmd = new SqlCommand ();
                cmd.Connection = bd.con;

                // CommandType para pode executar comando de PROCEDURE do Banco de dados.
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_CadCliente";

                // SqlParameter pnome = new SqlParameter ("@nome",SqlDbType.VarChar,50);
                // pnome.Value = cliente.NomeCliente;
                // cmd.Parameters.Add(pnome);

                // SqlParameter pemail = new SqlParameter ("@email",SqlDbType.VarChar,100);
                // pemail.Value = cliente.EmailCliente;
                // cmd.Parameters.Add(pemail);

                // SqlParameter pcpf = new SqlParameter ("@cpf",SqlDbType.VarChar,20);
                // pcpf.Value = cliente.CpfCliente;
                // cmd.Parameters.Add(pcpf);

                cmd.Parameters.Add (new SqlParameter ("@nome", cliente.NomeCliente));
                cmd.Parameters.Add (new SqlParameter ("@email", cliente.EmailCliente));
                cmd.Parameters.Add (new SqlParameter ("@cpf", cliente.CpfCliente));
                int rs = cmd.ExecuteNonQuery ();

                if (rs > 0) {
                    retorno = true;
                }
                cmd.Parameters.Clear ();

            } catch (SqlException se) {
                throw new Exception ("Erro ao manipular BD: " + se.Message);
            } catch (Exception ex) {
                throw new Exception ("Erro ao manipular BD: " + ex.Message);
            }

            return retorno;
        }

        public bool Deletar (Cliente cliente) {
            bool rs = false;
            try {
                bd.Open ();
                cmd = new SqlCommand ();
                cmd.Connection = bd.con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_DelCliente";

                cmd.Parameters.Add (new SqlParameter ("@id", cliente.IdCliente));

                int r = cmd.ExecuteNonQuery ();
                if (r > 0) {
                    rs = true;
                }
            } catch (SqlException se) {
                throw new Exception ("Erro ao manipular o banco: " + se.Message);
            } catch (Exception ex) {
                throw new Exception ("Erro inesperado: " + ex.Message);
            }

            return rs;
        }
    }
}