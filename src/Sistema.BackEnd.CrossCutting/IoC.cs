using Microsoft.Extensions.DependencyInjection;
using Sistema.BackEnd.Persistence.Repositories.Contracts;
using Sistema.BackEnd.Persistence.Repositories.Implementations;
using Sistema.BackEnd.Persistence.UnitOfWork.Contracts;
using Sistema.BackEnd.Persistence.UnitOfWork.Implementations;
using Sistema.BackEnd.Services.Contracts;
using Sistema.BackEnd.Services.Implementations;

namespace Sistema.BackEnd.CrossCutting
{
    public static class IoC
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            AddRegistrationRepositories(services);
            AddRegistrationServices(services);
            AddRegisterOthers(services);
            return services;

        }

        private static void AddRegisterOthers(IServiceCollection services)
        {

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        private static void AddRegistrationServices(IServiceCollection services)
        {
            services.AddTransient<ICategoriaService, CategoryService>();
        }

        private static void AddRegistrationRepositories(IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }
    }
}
