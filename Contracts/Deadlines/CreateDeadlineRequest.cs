namespace Contracts.Deadlines;

public record CreateDeadlineRequest(
    string Title,
    string? Description,
    DateTime DueTo,
    int? Difficulty,
    int? Priority,
    string OwnerId,
    List<ToDoTaskRequest> Tasks
);

public record ToDoTaskRequest(
    string Title,
    string? Description
);