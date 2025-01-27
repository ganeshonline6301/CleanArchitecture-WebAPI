using FluentValidation;
using CleanArch.Application.Common.Behaviours;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssemblyContaining(typeof(DependencyInjection));
            options.AddOpenBehavior(typeof(ValidationBehaviour<,>));
        });
        
        services.AddValidatorsFromAssemblyContaining(typeof(DependencyInjection));
        
        return services;
    }
}