
using Condominio.Applications.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Condominio.Applications.Interfaces
{
    public interface IResidencialAppService : IDisposable
    {
        Task<IEnumerable<ResidencialViewModel>> GetAll();
        Task<ResidencialViewModel> GetById(int residencialId);
        Task<bool> Register(ResidencialViewModel residencialViewModel);
        Task<bool> Update(ResidencialViewModel residencialViewModel);
        Task<bool> Remove(int id);
    }
}
