using Microsoft.Extensions.DependencyInjection;
using Placeholder.Data.Repositories;
using Placeholder.Domain.Abstractions;

namespace Placeholder.Data;

public static class DependencyInjection
{
    public static IServiceCollection AddData(this IServiceCollection services)
    {
        services.AddSingleton<IProfilesRepository, ProfilesRepository>();
        services.AddSingleton<IAddressRepository, AddressRepository>();

        return services;
    }
}