using Infrastructure.Common;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<DeadlinerDbContext>(options =>
            options.UseSqlite("DataSource=app.db"));
        
        services
            .AddIdentityCore<DbUser>()
            .AddEntityFrameworkStores<DeadlinerDbContext>()
            .AddApiEndpoints();
        
        return services;
    }
}