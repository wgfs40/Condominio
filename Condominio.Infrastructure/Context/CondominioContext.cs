using Condominio.Domain.Models;
using Condominio.Infrastructure.Context.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Condominio.Infrastructure.Context
{
    public class CondominioContext : DbContext
    {
        public CondominioContext(DbContextOptions<CondominioContext>options):base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CondominiusMap());
            modelBuilder.ApplyConfiguration(new PaymentMap());
            modelBuilder.ApplyConfiguration(new ResidencialMap());
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new DueMap());
            
            base.OnModelCreating(modelBuilder);
        }
       
    }
}
