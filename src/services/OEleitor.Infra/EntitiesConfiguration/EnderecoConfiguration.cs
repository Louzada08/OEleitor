using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OEleitor.Domain.Entities;

namespace OEleitor.Infra.EntitiesConfiguration
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Logradouro).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Numero).HasMaxLength(5).IsRequired(false);
            builder.Property(p => p.Complemento).HasMaxLength(30).IsRequired(false);
            builder.Property(p => p.Cep).HasMaxLength(50).IsRequired(false);
            builder.Property(p => p.Cidade).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Estado).HasMaxLength(2).IsRequired();
        }
    }
}
