using Application.Users.Persistence;
using Domain.UserAggregate;
using Infrastructure.Common;

namespace Infrastructure.Persistence.Repositories;

public class UserRepository(
    DeadlinerDbContext dbContext
) : IUserRepository
{
    private readonly DeadlinerDbContext _dbContext = dbContext;

    public async Task AddAsync(User user, CancellationToken cancellationToken)
    {
        await _dbContext.AddAsync(user.ToDbUser(), cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}

file static class UserExtensions
{
    public static DbUser ToDbUser(this User user) =>
        new()
        {
            Id = user.Id!,
            UserName = user.UserName,
            NormalizedUserName = user.NormalizedUserName,
            Email = user.Email,
            NormalizedEmail = user.NormalizedEmail,
            EmailConfirmed = user.EmailConfirmed,
            PasswordHash = user.PasswordHash,
            SecurityStamp = user.SecurityStamp,
            ConcurrencyStamp = user.ConcurrencyStamp,
            PhoneNumber = user.PhoneNumber,
            PhoneNumberConfirmed = user.PhoneNumberConfirmed,
            TwoFactorEnabled = user.TwoFactorEnabled,
            LockoutEnd = user.LockoutEnd,
            LockoutEnabled = user.LockoutEnabled,
            AccessFailedCount = user.AccessFailedCount
        };
}