using Microsoft.EntityFrameworkCore;
using WebApiBiopoints.Models;

namespace WebApiBiopoints.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options ) : base( options )
        {

        }

        public DbSet<UsuarioModel> Usuarios { get; set; }

        public DbSet<ProdutoModel> Produto { get; set; }
    }
}
