using Microsoft.Extensions.DependencyInjection;
using Placeholder.Core.Services;
using Placeholder.Domain.Abstractions;

namespace Placeholder.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddSingleton<IProfilesService, ProfilesService>();
        
        return services;
    }
}