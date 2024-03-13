using Microsoft.AspNetCore.Identity;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services
            .AddAuth()
            .AddControllers();

        return services;
    }

    private static IServiceCollection AddAuth(this IServiceCollection services)
    {
        services
            .AddAuthentication()
            .AddBearerToken(IdentityConstants.BearerScheme);

        services.AddAuthorizationBuilder();

        return services;
    }
}