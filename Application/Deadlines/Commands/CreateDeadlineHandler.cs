using Application.Deadlines.Persistence;
using Domain.DeadlineAggregate;
using Domain.DeadlineAggregate.Entities;

namespace Application.Deadlines.Commands;

public class CreateDeadlineHandler(
    IDeadlineRepository repository
) : IRequestHandler<CreateDeadlineCommand, ErrorOr<Deadline>>
{
    private readonly IDeadlineRepository _repository = repository;
    
    public async Task<ErrorOr<Deadline>> Handle(CreateDeadlineCommand command, CancellationToken cancellationToken)
    {
        var (title, description, dueTo, difficulty, priority, ownerId, tasks) = command;
        
        var deadline = Deadline.CreateNew
        (
            title,
            description,
            dueTo,
            difficulty,
            priority,
            ownerId,
            tasks.ConvertAll(task =>
                ToDoTask.CreateNew
                (
                    task.Title,
                    task.Description
                )
            )
        );

        await _repository.AddAsync(deadline, cancellationToken);

        return deadline;
    }
}