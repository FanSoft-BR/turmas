using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FanSoft.CadTurmas.CrossCutting.DI
{
    public static class Configuration
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            registerMediatr(services);
            registerData(services);
            registerAppServices(services);

        }

        private static void registerMediatr(IServiceCollection services)
        {
            const string applicationAssemblyName = "FanSoft.CadTurmas.Domain";
            var assembly = System.AppDomain.CurrentDomain.Load(applicationAssemblyName);

            FluentValidation.AssemblyScanner
                .FindValidatorsInAssembly(assembly)
                .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));

            services.AddScoped(typeof(MediatR.IPipelineBehavior<,>), typeof(Domain.Mediator.FailFastRequestBehavior<,>));

            services.AddMediatR(assembly);
        }

        private static void registerData(IServiceCollection services)
        {
            services.AddScoped<Data.EF.CadTurmasDataContext>();
            services.AddTransient<Domain.Contracts.Infra.Data.IUnitOfWork, Data.EF.UnitOfWorkEF>();

            services.AddTransient<Domain.Contracts.Repositories.ITurmaReadRepository, Data.EF.Repositories.TurmaReadRepositoryEF>();
            services.AddTransient<Domain.Contracts.Repositories.ITurmaWriteRepository, Data.EF.Repositories.TurmaWriteRepositoryEF>();

            services.AddTransient<Domain.Contracts.Repositories.IInstrutorReadRepository, Data.EF.Repositories.InstrutorReadRepositoryEF>();
            services.AddTransient<Domain.Contracts.Repositories.IInstrutorWriteRepository, Data.EF.Repositories.InstrutorWriteRepositoryEF>();

            services.AddTransient<Domain.Contracts.Repositories.IUsuarioReadRepository, Data.EF.Repositories.UsuarioReadRepositoryEF>();
            services.AddTransient<Domain.Contracts.Repositories.IUsuarioWriteRepository, Data.EF.Repositories.UsuarioWriteRepositoryEF>();

            services.AddTransient<Domain.Contracts.Repositories.IRoleReadRepository, Data.EF.Repositories.RoleReadRepositoryEF>();
            services.AddTransient<Domain.Contracts.Repositories.IRoleWriteRepository, Data.EF.Repositories.RoleWriteRepositoryEF>();
        }

        private static void registerAppServices(IServiceCollection services)
        {
            // services.AddTransient<Domain.Contracts.Infra.Service.ISendMail, Services.SendMail>();
        }
    }
}