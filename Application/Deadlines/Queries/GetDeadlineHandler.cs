using Domain.DeadlineAggregate;
using ErrorOr;
using MediatR;

namespace Application.Deadlines.Queries;

public class GetDeadlineHandler : IRequestHandler<GetDeadlineQuery, ErrorOr<Deadline>>
{
    public async Task<ErrorOr<Deadline>> Handle(GetDeadlineQuery request, CancellationToken cancellationToken)
    {
        var id = request.Id;
        
        await Task.CompletedTask;

        return Deadline.Create(id, "Title", "Description");
    }
}