using Application.Deadlines.Commands;
using Contracts.Deadlines;
using Domain.DeadlineAggregate;
using Domain.DeadlineAggregate.Enums;

namespace Api.Deadlines;

public static class Mapper
{
    public static CreateDeadlineCommand ToCommand(this CreateDeadlineRequest request)
        => new
        (
            request.Title,
            request.Description,
            request.DueTo,
            request.Difficulty.HasValue 
                ? (Difficulty)request.Difficulty.Value 
                : null, 
            request.Priority,
            request.OwnerId!,
            request.Tasks.ConvertAll(task =>
                new ToDoTaskCommand
                (
                    task.Title,
                    task.Description
                )    
            )
        );
    
    public static DeadlineResponse ToResponse(this Deadline deadline)
        => new
        (
            deadline.Id!,
            deadline.Title,
            deadline.Description,
            deadline.Tasks.Select(task => 
                new ToDoTaskResponse
                (
                    task.Id!,
                    task.Title,
                    task.Description ?? "",
                    task.Done
                )
            ).ToList()
        );
}