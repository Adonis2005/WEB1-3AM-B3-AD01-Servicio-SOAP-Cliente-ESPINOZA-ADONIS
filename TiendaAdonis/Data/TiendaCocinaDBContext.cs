using Microsoft.EntityFrameworkCore;
using TiendaAdonis.Models;

namespace TiendaAdonis.Data
{
    public class TiendaCocinaDBContext : DbContext
    {
        public TiendaCocinaDBContext(
            DbContextOptions<TiendaCocinaDBContext> options)
            : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; } = null!;
        public DbSet<Producto> Productos { get; set; } = null!;
    }
}