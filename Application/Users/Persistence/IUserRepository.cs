using Domain.UserAggregate;

namespace Application.Users.Persistence;

public interface IUserRepository
{
    public Task AddAsync(User user, CancellationToken cancellationToken = default);
}