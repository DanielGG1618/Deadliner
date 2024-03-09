using Contracts.Deadlines;
using Domain.DeadlineAggregate;

namespace Api.Deadlines;

public static class Mapper
{
    public static DeadlineResponse ToResponse(this Deadline deadline)
        => new(deadline.Id!, deadline.Title, deadline.Description);
}