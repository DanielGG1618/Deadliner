using Application.Deadlines.Persistence;
using Domain.Common.Errors;
using Domain.DeadlineAggregate;

namespace Application.Deadlines.Queries;

public class GetDeadlineHandler(
    IDeadlineRepository repository
) : IRequestHandler<GetDeadlineQuery, ErrorOr<Deadline>>
{
    private readonly IDeadlineRepository _repository = repository;
    
    public async Task<ErrorOr<Deadline>> Handle(GetDeadlineQuery request, CancellationToken cancellationToken)
    {
        var id = request.Id;

        var deadline = await _repository.GetAsync(id, cancellationToken);

        if (deadline is null)
            return Errors.Deadlines.NotFound(id);

        return deadline;
    }
}