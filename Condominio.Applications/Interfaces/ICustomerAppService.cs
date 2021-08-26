using Condominio.Applications.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Condominio.Applications.Interfaces
{
    public interface ICustomerAppService : IDisposable
    {
        Task<IEnumerable<CustomerViewModel>> GetAll();        
        Task<CustomerViewModel> GetById(int CustomerId);        
        Task<bool> Register(CustomerViewModel customerViewModel);
        Task<bool> Update(CustomerViewModel customerViewModel);
        Task<bool> Remove(int id);
    }
}
