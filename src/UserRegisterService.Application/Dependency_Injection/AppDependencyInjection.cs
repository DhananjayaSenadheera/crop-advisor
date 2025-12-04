using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using UserRegisterService.Application.Helper;
using UserRegisterService.Application.Mapping;
using UserRegisterService.Application.Requests.User.Validators;
using UserRegisterService.Domain.Interfaces;

namespace UserRegisterService.Application.Dependency_Injection;

public static class AppDependencyInjection
{
    public static IServiceCollection InjectAppLayer(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AppDependencyInjection).Assembly));
        services.AddAutoMapper(typeof(ProfileMapper));
        services.AddValidatorsFromAssemblyContaining<UserCreateValidator>();
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        
        return services;
    }
    
}