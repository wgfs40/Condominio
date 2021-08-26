using Condominio.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Condominio.Infrastructure.Context.Mapping
{
    public class PaymentMap : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(p => p.PaymentId);
            builder.Property(p => p.CustomerId).HasColumnType("int").IsRequired();
            builder.Property(p => p.PaymentsAmount).HasColumnType("money").IsRequired();
            builder.Property(p => p.PaymentDate).HasColumnType("DateTime").IsRequired();
            builder.ToTable("Payments");
        }
    }
}
