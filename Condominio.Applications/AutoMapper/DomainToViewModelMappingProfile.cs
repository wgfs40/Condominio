using AutoMapper;
using Condominio.Applications.ViewModels;
using Condominio.Domain.Models;

namespace Condominio.Applications.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<Condominium, CondominiumViewModel>();
            CreateMap<Residencial, ResidencialViewModel>();
            CreateMap<Due, DueViewModel>();
            CreateMap<Payment, PaymentViewModel>();
        }
    }
}
