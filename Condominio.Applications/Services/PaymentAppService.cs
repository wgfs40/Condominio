using AutoMapper;
using Condominio.Applications.Interfaces;
using Condominio.Applications.ViewModels;
using Condominio.Domain.Interfaces;
using Condominio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Condominio.Applications.Services
{
    public class PaymentAppService : IPaymentAppService
    {
        private readonly IMapper _mapper;
        private readonly IPaymentRepository _paymentRepository;

        public PaymentAppService(IMapper mapper, IPaymentRepository paymentRepository)
        {
            _mapper = mapper;
            _paymentRepository = paymentRepository;
        }

        public async Task<IEnumerable<PaymentViewModel>> GetAll()
        {
            var lista = await _paymentRepository.GetAll();
            return _mapper.Map<IEnumerable<PaymentViewModel>>(lista);
        }

        public async Task<IEnumerable<PaymentViewModel>> GetAllByCustomerId(int customerid)
        {
            var lista = await _paymentRepository.GetAllByCustomerId(customerid);
            return _mapper.Map<IEnumerable<PaymentViewModel>>(lista);
        }

        public async Task<PaymentViewModel> GetById(int paymentId)
        {
            return _mapper.Map<PaymentViewModel>(await _paymentRepository.GetById(paymentId));
        }

        public Task<bool> Register(PaymentViewModel paymentViewModel)
        {
            var residencial = _mapper.Map<Payment>(paymentViewModel);
            _paymentRepository.Add(residencial);
            return Task.FromResult(_paymentRepository.SaveChanges() > 0);
        }

        public Task<bool> Remove(int id)
        {
            var residencial = _mapper.Map<Payment>(new PaymentViewModel { PaymentId = id });
            _paymentRepository.Remove(residencial);
            return Task.FromResult(_paymentRepository.SaveChanges() > 0);
        }

        public Task<bool> Update(PaymentViewModel paymentViewModel)
        {
            var residencial = _mapper.Map<Payment>(paymentViewModel);
            _paymentRepository.Update(residencial);
            return Task.FromResult(_paymentRepository.SaveChanges() > 0);
        }

        public void Dispose()
        {
            _paymentRepository.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
