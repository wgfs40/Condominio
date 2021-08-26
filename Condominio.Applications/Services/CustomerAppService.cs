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
    public class CustomerAppService : ICustomerAppService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public CustomerAppService(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<CustomerViewModel>> GetAll()
        {
            var lista = await _customerRepository.GetAll();
            return _mapper.Map<IEnumerable<CustomerViewModel>>(lista);
        }

        public async Task<CustomerViewModel> GetById(int CustomerId)
        {
            return _mapper.Map<CustomerViewModel>(await _customerRepository.GetById(CustomerId));
        }

        public Task<bool> Register(CustomerViewModel customerViewModel)
        {
            var customer = _mapper.Map<Customer>(customerViewModel);
            _customerRepository.Add(customer);
            return Task.FromResult(_customerRepository.SaveChanges() > 0);
        }

        public Task<bool> Remove(int id)
        {
            var customer = _mapper.Map<Customer>(new CustomerViewModel { CustomerId = id });
            _customerRepository.Remove(customer);
            return Task.FromResult(_customerRepository.SaveChanges() > 0);
        }

        public Task<bool> Update(CustomerViewModel customerViewModel)
        {
            var customer = _mapper.Map<Customer>(customerViewModel);
            _customerRepository.Update(customer);
            return Task.FromResult(_customerRepository.SaveChanges() > 0);
        }

        public void Dispose()
        {
            _customerRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
