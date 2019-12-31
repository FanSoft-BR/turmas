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
            // const string applicationAssemblyName = "FanSoft.AM.Domain";
            // var assembly = AppDomain.CurrentDomain.Load(applicationAssemblyName);

            // AssemblyScanner
            //     .FindValidatorsInAssembly(assembly)
            //     .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));

            // services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastRequestBehavior<,>));

            // services.AddMediatR();
        }

        private static void registerData(IServiceCollection services)
        {
            services.AddScoped<Data.EF.CadTurmasDataContext>();
            services.AddTransient<Domain.Contracts.Infra.Data.IUnitOfWork, Data.EF.UnitOfWorkEF>();

            services.AddTransient<Domain.Contracts.Repositories.ITurmaReadRepository, Data.EF.Repositories.TurmaReadRepositoryEF>();
            services.AddTransient<Domain.Contracts.Repositories.ITurmaWriteRepository, Data.EF.Repositories.TurmaWriteRepositoryEF>();
        }

        private static void registerAppServices(IServiceCollection services)
        {
            // services.AddTransient<Domain.Contracts.Infra.Service.ISendMail, Services.SendMail>();
        }
    }
}