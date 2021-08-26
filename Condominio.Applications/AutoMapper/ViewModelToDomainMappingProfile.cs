using AutoMapper;
using Condominio.Applications.ViewModels;
using Condominio.Domain.Models;

namespace Condominio.Applications.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CondominiumViewModel, Condominium>()
                 .ConstructUsing(c => new Condominium(c.CondominiumId,c.BusinessName,c.Phone,c.Address,c.Email));

            CreateMap<ResidencialViewModel, Residencial>()
                 .ConstructUsing(r => new Residencial(r.ResidentialId,r.CondominiumId,r.ResidentialName));

            CreateMap<CustomerViewModel, Customer>()
                 .ConstructUsing(c => new Customer(c.CustomerId,c.ResidentialId, c.FirstName, c.LastName, c.Phone, c.Email));

            CreateMap<DueViewModel, Due>()
                 .ConstructUsing(d => new Due(d.DueId,d.CustomerId,d.Amount,d.PaymentDay,d.PercentCharges));

            CreateMap<PaymentViewModel, Payment>()
                 .ConstructUsing(p => new Payment(p.PaymentId,p.CustomerId,p.PaymentsAmount,p.PaymentDate));
        }
    }
}
