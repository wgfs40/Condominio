using Condominio.Domain.Interfaces;
using Condominio.Domain.Models;
using Condominio.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Condominio.Infrastructure.Repository
{
    public class ResidencialRespository : IResidencialRespository
    {
        protected readonly CondominioContext Db;
        protected readonly DbSet<Residencial> DbSet;

        public ResidencialRespository(CondominioContext condominioContext)
        {
            Db = condominioContext;
            DbSet = Db.Set<Residencial>();
        }
        public void Add(Residencial residencial)
        {
            DbSet.Add(residencial);
        }
        
        public async Task<IEnumerable<Residencial>> GetAll()
        {
            var residelcial = await DbSet.Include(c => c.Condominium).ToListAsync();
            return residelcial;
        }

        public async Task<Residencial> GetById(int ResidentialId)
        {
            return await DbSet.FindAsync(ResidentialId);
        }

        public void Remove(Residencial residencial)
        {
            DbSet.Remove(residencial);
        }

        public void Update(Residencial residencial)
        {
            DbSet.Update(residencial);
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }
        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
