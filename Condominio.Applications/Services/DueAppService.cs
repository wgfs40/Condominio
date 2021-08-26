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
    public class DueAppService : IDueAppService
    {
        private readonly IMapper _mapper;
        private readonly IDueRepository _dueRepository;

        public DueAppService(IMapper mapper, IDueRepository dueRepository)
        {
            _mapper = mapper;
            _dueRepository = dueRepository;
        }

        public async Task<IEnumerable<DueViewModel>> GetAll()
        {
            var lista = await _dueRepository.GetAll();
            return _mapper.Map<IEnumerable<DueViewModel>>(lista);
        }
        public async Task<IEnumerable<DueViewModel>> GetAllByCustomerId(int customerid)
        {
            var lista = await _dueRepository.GetAllByCustomerId(customerid);
            return _mapper.Map<IEnumerable<DueViewModel>>(lista);
        }

        public async Task<DueViewModel> GetById(int dueId)
        {
            return _mapper.Map<DueViewModel>(await _dueRepository.GetById(dueId));
        }

        public Task<bool> Register(DueViewModel dueViewModel)
        {
            var residencial = _mapper.Map<Due>(dueViewModel);
            _dueRepository.Add(residencial);
            return Task.FromResult(_dueRepository.SaveChanges() > 0);
        }

        public Task<bool> Remove(int id)
        {
            var residencial = _mapper.Map<Due>(new DueViewModel { DueId = id });
            _dueRepository.Remove(residencial);
            return Task.FromResult(_dueRepository.SaveChanges() > 0);
        }

        public Task<bool> Update(DueViewModel dueViewModel)
        {
            var residencial = _mapper.Map<Due>(dueViewModel);
            _dueRepository.Update(residencial);
            return Task.FromResult(_dueRepository.SaveChanges() > 0);
        }

        public void Dispose()
        {
            _dueRepository.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
