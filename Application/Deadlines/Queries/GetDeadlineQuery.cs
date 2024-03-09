using Domain.DeadlineAggregate;
using Domain.DeadlineAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace Application.Deadlines.Queries;

public record GetDeadlineQuery(DeadlineId Id) : IRequest<ErrorOr<Deadline>>;