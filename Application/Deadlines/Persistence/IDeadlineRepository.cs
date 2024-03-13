using Domain.DeadlineAggregate;
using Domain.DeadlineAggregate.ValueObjects;

namespace Application.Deadlines.Persistence;

public interface IDeadlineRepository
{
    public Task<Deadline?> GetAsync(DeadlineId id, CancellationToken cancellationToken = default);
    public Task AddAsync(Deadline deadline, CancellationToken cancellationToken = default);
}