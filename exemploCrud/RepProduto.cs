using System.Data.SqlClient;

namespace exemploCrud {
    public class RepProduto {
        AcessaBD bd = new AcessaBD ();
        SqlCommand cmd;
        SqlDataReader dr;

        public RepProduto () {
            bd.Open ();

        }
    }
}