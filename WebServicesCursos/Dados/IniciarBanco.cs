using System;
using System.Linq;
using WebServicesCursos.Model;

namespace WebServicesCursos.Dados {
    public class IniciarBanco {
        public static void Inicializar (CursosContexto contexto) {
            contexto.Database.EnsureCreated ();

            if (contexto.Area.Any ()) {
                return;
            }

            var area = new Area () {
                Nome = "Teste Area"
            };
            contexto.Area.Add (area);

            var curso = new Curso () {
                Nome = "Teste Curso",
                IdArea = area.IdArea
            };
            contexto.Curso.Add (curso);

            var dataHora = new DataHora () {
                DataInicio = "2018-02-01",
                DataFim = "2018-02-30",
                HoraInicio = "18:00:00",
                HoraFim = "22:00:00",
                DiaSemana = "2ª, 3ª, 4ª, 5ª, 6ª",
                IdCurso = curso.IdCurso
            };
            contexto.DataHora.Add (dataHora);

            contexto.SaveChanges ();
        }
    }
}