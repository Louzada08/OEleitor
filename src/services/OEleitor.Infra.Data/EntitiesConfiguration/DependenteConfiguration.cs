using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OEleitor.Domain.Entities;

namespace OEleitor.Infra.Data.EntitiesConfiguration
{
    public class DependenteConfiguration : IEntityTypeConfiguration<Dependente>
    {
        public void Configure(EntityTypeBuilder<Dependente> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();

            builder.HasOne(f => f.Eleitor)
                .WithMany(c => c.Dependentes)
                .HasForeignKey(c => c.EleitorId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
