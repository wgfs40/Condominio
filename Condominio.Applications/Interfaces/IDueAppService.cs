using Condominio.Applications.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Condominio.Applications.Interfaces
{
    public interface IDueAppService : IDisposable
    {
        Task<IEnumerable<DueViewModel>> GetAll();
        Task<DueViewModel> GetById(int dueId);
        Task<IEnumerable<DueViewModel>> GetAllByCustomerId(int customerid);
        Task<bool> Register(DueViewModel dueViewModel);
        Task<bool> Update(DueViewModel dueViewModel);
        Task<bool> Remove(int id);
    }
}
