using System.Collections.Generic;
using WebServicesForum.Models;

namespace WebServicesForum.DAO {
    interface IAcoes {
        bool Cadastrar ();
        bool Atualizar();
        bool Deletar ();
    }
}