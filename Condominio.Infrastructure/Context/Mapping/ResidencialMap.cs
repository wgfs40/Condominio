using Condominio.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Condominio.Infrastructure.Context.Mapping
{
    public class ResidencialMap : IEntityTypeConfiguration<Residencial>
    {
        public void Configure(EntityTypeBuilder<Residencial> builder)
        {
            builder.HasKey(r => r.ResidentialId);
            builder.Property(r => r.CondominiumId).HasColumnType("int").IsRequired();
            builder.Property(r => r.ResidentialName).HasColumnType("varchar").HasMaxLength(250).IsRequired();

            //asosiations
            builder.HasOne(r => r.Condominium)
                .WithMany(c => c.Residencials)
                .HasForeignKey(r => r.CondominiumId);

            builder.ToTable("Residencials");
        }
    }
}
