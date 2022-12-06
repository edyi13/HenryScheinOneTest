using HenryScheinOneTest.Application.Interface;
using HenryScheinOneTest.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace HenryScheinOneTest.Infrastructure.Persistence
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInjectionPersistence(this IServiceCollection services)
        {
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
