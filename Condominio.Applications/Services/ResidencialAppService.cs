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
    public class ResidencialAppService : IResidencialAppService
    {
        private readonly IMapper _mapper;
        private readonly IResidencialRespository _residencialRepository;
        public ResidencialAppService(IMapper mapper, IResidencialRespository residencialRepository)
        {
            _mapper = mapper;
            _residencialRepository = residencialRepository;
        }

        public async Task<IEnumerable<ResidencialViewModel>> GetAll()
        {
            var lista = await _residencialRepository.GetAll();
            return _mapper.Map<IEnumerable<ResidencialViewModel>>(lista);
        }

        public async Task<ResidencialViewModel> GetById(int residencialId)
        {
            return _mapper.Map<ResidencialViewModel>(await _residencialRepository.GetById(residencialId));
        }

        public Task<bool> Register(ResidencialViewModel residencialViewModel)
        {
            var residencial = _mapper.Map<Residencial>(residencialViewModel);
            _residencialRepository.Add(residencial);
            return Task.FromResult(_residencialRepository.SaveChanges() > 0);
        }

        public Task<bool> Remove(int id)
        {
            var residencial = _mapper.Map<Residencial>(new ResidencialViewModel { ResidentialId = id });
            _residencialRepository.Remove(residencial);
            return Task.FromResult(_residencialRepository.SaveChanges() > 0);
        }

        public Task<bool> Update(ResidencialViewModel residencialViewModel)
        {
            var residencial = _mapper.Map<Residencial>(residencialViewModel);
            _residencialRepository.Update(residencial);
            return Task.FromResult(_residencialRepository.SaveChanges() > 0);
        }

        public void Dispose()
        {
            _residencialRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
