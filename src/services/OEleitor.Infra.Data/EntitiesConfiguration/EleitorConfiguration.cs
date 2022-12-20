using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OEleitor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEleitor.Infra.Data.EntitiesConfiguration
{
    public class EleitorConfiguration : IEntityTypeConfiguration<Eleitor>
    {
        public void Configure(EntityTypeBuilder<Eleitor> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();
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
                    .HasColumnName("Fone1TemWhatsapp");
            });

            builder.OwnsOne(c => c.Endereco, tf =>
            {
                tf.Property(c => c.Logradouro)
                    .IsRequired()
                    .HasColumnName("Logradouro")
                    .HasColumnType($"varchar(150)");

                tf.Property(c => c.Numero)
                    .IsRequired(false)
                    .HasColumnName("Numero")
                    .HasColumnType($"varchar(5)");

                tf.Property(c => c.Cidade)
                    .IsRequired()
                    .HasColumnName("Cidade")
;
                tf.Property(c => c.Estado)
                    .IsRequired()
                    .HasColumnType($"varchar(2)");

                tf.Property(c => c.Cep)
                    .IsRequired()
                    .HasColumnType($"varchar(9)");
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
