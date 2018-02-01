using Microsoft.EntityFrameworkCore;
using PrimeiroEF.Models;

namespace PrimeiroEF.Dados {
    public class ClienteContexto : DbContext {
        public ClienteContexto (DbContextOptions<ClienteContexto> options) : base (options) {

        }
        public DbSet<Cliente> ClienteBase { get; set; }
    }
}