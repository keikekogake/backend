using System;
using System.IO;
using System.Text;

namespace SysLog {
    public class Usuario : IUsuario {
        public string User { get; set; }
        public string Senha { get; set; }

        public Usuario () { }

        public Usuario (string user, string senha) {
            this.User = user;
            this.Senha = senha;
        }
        public string Cadastrar (string usuario, string senha) {
            string msg = "";
            StreamWriter sw = null;

            try {
                sw = new StreamWriter ("_usuario.txt", true);
                sw.WriteLine (usuario + ";" + senha);
                msg = "Usuario cadastrado";
            } catch (Exception ex) {
                msg = "Erro ao manipular o arquivo: " + ex.Message;
            } finally {
                sw.Close ();
            }

            return msg;
        }

        public string Logar (string usuarioEntrada, string senhaEntrada) {
            string[] array;
            string msg = "";
            string linha = "";
            StreamReader sr = null;

            try {
                sr = new StreamReader ("_usuario.txt", Encoding.Default);
                while ((linha = sr.ReadLine ()) != null) {
                    array = linha.Split (';');
                    if (usuarioEntrada == array[0] && senhaEntrada == array[1]) {
                        msg = "Usuário válido";
                        this.ELog (usuarioEntrada, "logou");
                    }
                }
            } catch (Exception ex) {
                msg = "Erro ao manipular o arquivo" + ex.Message;
            } finally {
                sr.Close ();
            }
            return msg;
        }

        

        public void Log (string usuario, string acao) {
            StreamWriter sw = null;
            try {
                sw = new StreamWriter ("_superior.txt", true);
                sw.WriteLine ("O usuário " + usuario + " " + acao + " no sistema as " + DateTime.Now.ToShortDateString () + " " + DateTime.Now.ToShortTimeString ());
            } catch (Exception ex) {

                throw new Exception ("Erro ao manipular o arquivo superior: " + ex.Message);
            } finally {
                sw.Close ();
            }
            try {
                sw = new StreamWriter ("_log.txt", true);
                sw.WriteLine ("O usuário " + usuario + " " + acao + " no sistema as " + DateTime.Now.ToShortDateString () + " " + DateTime.Now.ToShortTimeString ());
            } catch (Exception ex) {

                throw new Exception ("Erro ao manipular o arquivo log: " + ex.Message);
            } finally {
                sw.Close ();
            }
        }

        public delegate void DLog (string usuario, string acao);
        public event DLog ELog;

        public string Logar () {
            throw new System.NotImplementedException ();
        }
        public string Cadastrar () {
            throw new NotImplementedException ();
        }
    }
}