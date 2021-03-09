using Microsoft.EntityFrameworkCore;
using Sistema.BackEnd.Models;
using Sistema.BackEnd.Persistence.FluentApiConfig;

namespace Sistema.BackEnd.Persistence
{
    public class SistemaDbContext : DbContext
    {
        public SistemaDbContext(DbContextOptions<SistemaDbContext> options) : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            new CategoriaConfig(builder.Entity<Categoria>());
        }
    }
}
