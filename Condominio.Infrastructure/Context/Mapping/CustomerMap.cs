using Condominio.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Condominio.Infrastructure.Context.Mapping
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.CustomerId);
            builder.Property(c => c.ResidentialId).HasColumnType("int").IsRequired();
            builder.Property(c => c.FirstName).HasColumnType("varchar").HasMaxLength(150).IsRequired();
            builder.Property(c => c.LastName).HasColumnType("varchar").HasMaxLength(200).IsRequired();
            builder.Property(c => c.Phone).HasColumnType("varchar").HasMaxLength(13);
            builder.Property(c => c.Email).HasColumnType("varchar").HasMaxLength(200);

            //asociation
            builder.HasOne(c => c.Residencial)
                .WithMany(r => r.Customer)
                .HasForeignKey(c => c.ResidentialId);
                

            builder.ToTable("Customers");
        }
    }
}
