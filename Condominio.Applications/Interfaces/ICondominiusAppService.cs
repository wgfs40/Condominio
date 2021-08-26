using Condominio.Applications.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Condominio.Applications.Interfaces
{
    public interface ICondominiusAppService : IDisposable
    {
        Task<IEnumerable<CondominiumViewModel>> GetAll();
        Task<CondominiumViewModel> GetById(int CondominiusId);
        Task<bool> Register(CondominiumViewModel condominiumViewModel);
        Task<bool> Update(CondominiumViewModel condominiumViewModel);
        Task<bool> Remove(int id);
    }
}
