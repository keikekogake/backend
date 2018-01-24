using System;
using System.IO;

namespace ProjetoEvento.ClassePai.ClassesFilhas {
    public class Teatro : Evento {

        public string[] Elenco { get; set; }
        public string Diretor { get; set; }
        public string GeneroTeatro { get; set; }

        public Teatro () { }
        public Teatro (string[] elenco, string diretor, string generoteatro, string titulo, int classificacao, int lotacao, string duracao, DateTime data, string local) {
            this.Elenco = elenco;
            this.Diretor = diretor;
            this.GeneroTeatro = generoteatro;
            base.Titulo = titulo;
            base.Classificacao = classificacao;
            base.Lotacao = lotacao;
            base.Duracao = duracao;
            base.Data = data;
            base.Local = local;
        }

        public override bool Cadastrar () {
            bool efetuado = false;
            StreamWriter sw = null;
            FileInfo fi = new FileInfo ("_Teatro.csv");

            try {
                sw = new StreamWriter ("_Teatro.csv", true);
                foreach (var elenco in Elenco) {
                    if (fi.Length == 0) {
                        sw.WriteLine ("Elenco;Diretor;GeneroTeatro;Titulo;Classificacao;Lotacao;Duracao;Data;Local");
                        sw.WriteLine (Elenco + ";" + Diretor + ";" + GeneroTeatro + ";" + Titulo + ";" + Classificacao + ";" + Lotacao + ";" + Duracao + ";" + Data + ";" + Local);
                    } else {
                        sw.WriteLine (Elenco + ";" + Diretor + ";" + GeneroTeatro + ";" + Titulo + ";" + Classificacao + ";" + Lotacao + ";" + Duracao + ";" + Data + ";" + Local);
                    }
                }
                efetuado = true;
            } catch (Exception ex) {

                throw new Exception ("Erro ao manipular o arquivo: " + ex.Message);
            } finally {
                sw.Close ();
            }

            return efetuado;
        }

        public override string Pesquisar (string TituloEvento) {
            string resultado = "Titulo não encontrado";
            StreamReader sr = null;

            try {
                sr = new StreamReader ("_Teatro.csv");
                string linha = "";
                while ((linha = sr.ReadLine ()) != null) {
                    string[] dados = linha.Split (';');
                    if (dados[3] == TituloEvento) {
                        resultado = linha;
                        break;
                    }
                }
            } catch (Exception ex) {
                resultado = "Erro ao manipular o arquivo: " + ex.Message;
            } finally {
                sr.Close ();
            }
            return resultado;
        }

        public override string Pesquisar (DateTime DataEvento) {
            string resultado = "Nenhum evento nesta data";
            StreamReader sr = null;

            try {
                sr = new StreamReader ("_Teatro.csv");
                string linha = "";
                while ((linha = sr.ReadLine ()) != null) {
                    string[] dados = linha.Split (';');
                    if (dados[7] == DataEvento.ToString ()) {
                        resultado = linha;
                        break;
                    }
                }
            } catch (Exception ex) {
                resultado = "Erro ao manipular o arquivo: " + ex.Message;
            } finally {
                sr.Close ();
            }
            return resultado;
        }

        public override string Pesquisar (string[] AtorEntrada) {
            string resultado = "Nenhum evento com os atores citados";
            StreamReader sr = null;

            try {
                sr = new StreamReader ("_Teatro.csv");
                string linha = "";

                while ((linha = sr.ReadLine ()) != null) {
                    string[] dados = linha.Split (';');
                    string[] atores = dados[0].Split (',');

                    for (int a = 0; a < atores.Length; a++) {
                        for (int b = 0; b < AtorEntrada.Length; b++) {
                            if (atores[a] == AtorEntrada[b]) {
                                resultado = linha;
                            }
                        }
                    }
                }
            } catch (Exception ex) {
                resultado = "Erro ao manipular o arquivo: " + ex.Message;
            } finally {
                sr.Close();
            }
            return resultado;
        }
    }
}