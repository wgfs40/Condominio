using Condominio.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Condominio.Infrastructure.Context.Mapping
{
    public class CondominiusMap : IEntityTypeConfiguration<Condominium>
    {
        public void Configure(EntityTypeBuilder<Condominium> builder)
        {
            builder.HasKey(co => co.CondominiumId);
            builder.Property(co => co.CondominiumId).ValueGeneratedOnAdd();
            builder.Property(co => co.BusinessName).HasColumnType("varchar").HasMaxLength(250).IsRequired();
            builder.Property(co => co.Phone).HasColumnType("varchar").HasMaxLength(13).IsRequired();
            builder.Property(co => co.Address).HasColumnType("varchar").HasMaxLength(500).IsRequired();
            builder.Property(co => co.Email).HasColumnType("varchar").HasMaxLength(250).IsRequired();
            builder.ToTable("Condominiums");
        }
    }
}
