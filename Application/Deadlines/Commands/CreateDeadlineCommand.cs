using Domain.DeadlineAggregate;
using Domain.DeadlineAggregate.Enums;
using Domain.UserAggregate.ValueObjects;

namespace Application.Deadlines.Commands;

public record CreateDeadlineCommand(
    string Title,
    string? Description,
    DateTime DueTo,
    Difficulty? Difficulty,
    int? Priority,
    UserId OwnerId, 
    List<ToDoTaskCommand> Tasks
) : IRequest<ErrorOr<Deadline>>;

public record ToDoTaskCommand(
    string Title,
    string? Description
);