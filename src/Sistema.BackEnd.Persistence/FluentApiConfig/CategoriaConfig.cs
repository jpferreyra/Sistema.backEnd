using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.BackEnd.Models;

namespace Sistema.BackEnd.Persistence.FluentApiConfig
{
    public class CategoriaConfig
    {
        public CategoriaConfig(EntityTypeBuilder<Categoria> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Descripcion).HasMaxLength(150);
            entityBuilder.Property(x => x.Nombre).IsRequired().HasMaxLength(100);
        }
    }
}
