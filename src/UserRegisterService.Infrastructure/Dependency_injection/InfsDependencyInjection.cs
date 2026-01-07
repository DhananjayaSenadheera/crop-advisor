using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserRegisterService.Domain.Interfaces;
using UserRegisterService.Insfractrucure.Database;
using UserRegisterService.Insfractrucure.Repositories;

namespace UserRegisterService.Insfractrucure.Dependency_injection;

public static class InfsDependencyInjection
{
    public static IServiceCollection InjectInfLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork, UnitofWorkRepository>();
        services.DabaseService(configuration);
        return services;
    }
}