using Microsoft.Extensions.DependencyInjection;

namespace Listless.Domain;

/// <summary>
/// A class to register domain services with the DI container.
/// </summary>
public static class DomainRegistration
{
    /// <summary>
    /// Registers domain services with the DI container.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection RegisterDomainServices(this IServiceCollection services)
    {
        // TODO: Register your domain services here
        return services;
    }
}
