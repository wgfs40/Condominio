using Condominio.Applications.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Condominio.Applications.Interfaces
{
    public interface IPaymentAppService : IDisposable
    {
        Task<IEnumerable<PaymentViewModel>> GetAll();
        Task<IEnumerable<PaymentViewModel>> GetAllByCustomerId(int customerid);
        Task<PaymentViewModel> GetById(int paymentId);
        Task<bool> Register(PaymentViewModel paymentViewModel);
        Task<bool> Update(PaymentViewModel paymentViewModel);
        Task<bool> Remove(int id);
    }
}
