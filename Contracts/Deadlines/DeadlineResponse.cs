namespace Contracts.Deadlines;

public record DeadlineResponse(
    string Id,
    string Title,
    string Description,
    List<ToDoTaskResponse> Tasks
);

public record ToDoTaskResponse(
    string Id,
    string Title,
    string Description,
    bool Done
);