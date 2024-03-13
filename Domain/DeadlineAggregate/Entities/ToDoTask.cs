using Domain.DeadlineAggregate.ValueObjects;

namespace Domain.DeadlineAggregate.Entities;

public class ToDoTask : EntityBase<ToDoTaskId>
{
    public string Title { get; }
    public string? Description { get; }
    public bool Done { get; private set; } = false;
    //TODO attachments

    private ToDoTask(ToDoTaskId id, string title, string? description, bool done = false) : base(id)
    {
        Title = title;
        Description = description;
        Done = done;
    }

    public void MarkAsDone() => Done = true;

    public static ToDoTask Create(ToDoTaskId id, string title, string? description) 
        => new(id, title, description);
    
    public static ToDoTask CreateNew(string title, string? description) 
        => new(ToDoTaskId.CreateUnique(), title, description);
}