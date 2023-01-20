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

            builder.HasOne(f => f.Endereco)
                .WithOne(c => c.Eleitor)
                .HasForeignKey<Endereco>(c => c.EleitorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(f => f.Dependentes)
                .WithOne(c => c.Eleitor)
                .HasForeignKey(c => c.EleitorId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
