using Condominio.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Condominio.Infrastructure.Context.Mapping
{
    public class DueMap : IEntityTypeConfiguration<Due>
    {
        public void Configure(EntityTypeBuilder<Due> builder)
        {
            builder.HasKey(d => d.DueId);
            builder.Property(d => d.CustomerId).HasColumnType("int").IsRequired();
            builder.Property(d => d.Amount).HasColumnType("money").IsRequired();
            builder.Property(d => d.PaymentDay).HasColumnType("int").IsRequired();
            builder.Property(d => d.PercentCharges).HasColumnType("decimal").IsRequired();
            builder.ToTable("Dues");
        }
    }
}
