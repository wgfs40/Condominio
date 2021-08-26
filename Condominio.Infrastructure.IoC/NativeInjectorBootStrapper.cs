using Microsoft.Extensions.DependencyInjection;
using Condominio.Infrastructure.Repository;
using Condominio.Domain.Interfaces;
using Condominio.Infrastructure.Context;
using Condominio.Applications.Interfaces;
using Condominio.Applications.Services;

namespace Condominio.Infrastructure.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void  RegisterServices(IServiceCollection services)
        {


            // Application
            services.AddScoped<ICondominiusAppService, CondominiusAppService>();
            services.AddScoped<IResidencialAppService, ResidencialAppService>();
            services.AddScoped<ICustomerAppService, CustomerAppService>();
            services.AddScoped<IDueAppService, DueAppService>();
            services.AddScoped<IPaymentAppService, PaymentAppService>();


            // Infra - Data
            services.AddScoped<ICondominiusRepository, CondominiusRepository>();
            services.AddScoped<IResidencialRespository, ResidencialRespository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IDueRepository, DueRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<CondominioContext>();
        }
    }
}
