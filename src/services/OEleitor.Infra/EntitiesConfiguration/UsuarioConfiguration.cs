using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OEleitor.Domain.Entities;

namespace OEleitor.Infra.EntitiesConfiguration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(u => u.Login).IsRequired();
            builder.Property(u => u.Senha).IsRequired().HasMaxLength(30);

            builder.ToTable("Usuarios");
        }
    }
}
