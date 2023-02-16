using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OEleitor.Domain.Entities;

namespace OEleitor.Infra.EntitiesConfiguration
{
    public class EleitorConfiguration : IEntityTypeConfiguration<Eleitor>
    {
        public void Configure(EntityTypeBuilder<Eleitor> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Apelido).HasMaxLength(50).IsRequired(false);
            builder.Property(p => p.Observacao).HasMaxLength(200).IsRequired();

            builder.OwnsOne(e => e.Endereco, ender =>
            {
                ender.Property(c => c.Logradouro)
                    .IsRequired()
                    .HasColumnType($"varchar(80)");

                ender.Property(c => c.Numero)
                    .IsRequired(false);

                ender.Property(c => c.Complemento)
                    .IsRequired(false)
                    .HasColumnType($"varchar(20)");

                ender.Property(c => c.Cep)
                    .IsRequired(false)
                    .HasColumnType($"varchar(10)");

                ender.Property(c => c.Cidade)
                    .IsRequired()
                    .HasColumnType($"varchar(50)");

                ender.Property(c => c.Estado)
                    .IsRequired()
                    .HasColumnType($"varchar(02)");
            });

            builder.OwnsOne(c => c.Fone, tf =>
            {
                tf.Property(c => c.Fone1)
                    .IsRequired(false)
                    .HasColumnName("Fone1")
                    .HasColumnType($"varchar(15)");

                tf.Property(c => c.Fone1TemWhatsapp)
                    .IsRequired(false)
                    .HasColumnName("Fone1TemWhatsapp");

                tf.Property(c => c.Fone2)
                    .IsRequired(false)
                    .HasColumnName("Fone2")
                    .HasColumnType($"varchar(15)");

                tf.Property(c => c.Fone2TemWhatsapp)
                    .IsRequired(false)
                    .HasColumnName("Fone2TemWhatsapp");
            });

            builder.HasOne(b => b.Bairro).WithOne();

            builder.HasMany(f => f.Dependentes)
                .WithOne(c => c.Eleitor)
                .HasForeignKey(c => c.EleitorId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
