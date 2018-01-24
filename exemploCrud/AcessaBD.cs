using System.Data.SqlClient;

namespace exemploCrud {
    public class AcessaBD {
        public SqlConnection con;
        public AcessaBD () {
            con = new SqlConnection ();
            con.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=Papelaria;User Id=sa;Password=senai@123";
        }
        public void Open () {
            con.Open ();
        }
        public void Close () {
            con.Close ();
        }
    }
}