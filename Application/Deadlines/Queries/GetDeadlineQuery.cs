using Domain.DeadlineAggregate;
using Domain.DeadlineAggregate.ValueObjects;

namespace Application.Deadlines.Queries;

public record GetDeadlineQuery(DeadlineId Id) : IRequest<ErrorOr<Deadline>>;