using BupaDinner.Application.Common.Interfaces.Authentication;
using BupaDinner.Application.Common.Services;
using BupaDinner.Infrastructure.Authentication;
using BupaDinner.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BupaDinner.Infrastructure;

public static class DependencyInjection 
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    { 
       services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
       
       services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
       services.AddSingleton<IDateTimeProvider, DateTimeProvider>(); 
       return services;
    }
}