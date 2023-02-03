using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OEleitor.Domain.Entities;

namespace OEleitor.Infra.EntitiesConfiguration
{
    public class BairroConfiguration : IEntityTypeConfiguration<Bairro>
    {
        public void Configure(EntityTypeBuilder<Bairro> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.BairroNome).HasMaxLength(50).IsRequired();

            //builder.HasOne(d => d.Endereco)
            //    .WithOne(p => p.Bairro)
            //    .HasForeignKey<Endereco>(fk => fk.BairroId)
            //    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
