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
    public class CondominiusAppService : ICondominiusAppService
    {
        private readonly IMapper _mapper;
        private readonly ICondominiusRepository _condominiusRepository;
        public CondominiusAppService(IMapper mapper, ICondominiusRepository condominiusRepository)
        {
            _mapper = mapper;
            _condominiusRepository = condominiusRepository;
        }      

        public async Task<IEnumerable<CondominiumViewModel>> GetAll()
        {
            var lista = await _condominiusRepository.GetAll();            
            return _mapper.Map<IEnumerable<CondominiumViewModel>>(lista);
        }

        public async Task<CondominiumViewModel> GetById(int CondominiusId)
        {
            return _mapper.Map<CondominiumViewModel>(await _condominiusRepository.GetById(CondominiusId));
        }

        public Task<bool> Register(CondominiumViewModel condominiumViewModel)
        {
            var condominium = _mapper.Map<Condominium>(condominiumViewModel);
            _condominiusRepository.Add(condominium);
            return Task.FromResult(_condominiusRepository.SaveChanges() > 0);
        }

        public Task<bool> Remove(int id)
        {
            var condominium = _mapper.Map<Condominium>(new CondominiumViewModel { CondominiumId = id});
            _condominiusRepository.Remove(condominium);
            return Task.FromResult(_condominiusRepository.SaveChanges() > 0);
        }

        public Task<bool> Update(CondominiumViewModel condominiumViewModel)
        {
            var condominium = _mapper.Map<Condominium>(condominiumViewModel);
            _condominiusRepository.Update(condominium);
            return Task.FromResult(_condominiusRepository.SaveChanges() > 0);
        }

        public void Dispose()
        {
            _condominiusRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
