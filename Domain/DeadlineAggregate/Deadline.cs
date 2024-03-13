using Domain.DeadlineAggregate.Entities;
using Domain.DeadlineAggregate.Enums;
using Domain.DeadlineAggregate.ValueObjects;
using Domain.UserAggregate.ValueObjects;

namespace Domain.DeadlineAggregate;

public class Deadline : AggregateRoot<DeadlineId>
{
    private readonly List<ToDoTask> _tasks;
    
    public string Title { get; }
    public string Description { get; }
    public DateTime DueTo { get; private set; }
    public Difficulty Difficulty { get; private set; }
    public int Priority { get; private set; }
    public UserId OwnerId { get; }
    public IReadOnlyList<ToDoTask> Tasks => _tasks.AsReadOnly();

    private Deadline
    (
        DeadlineId id, string title, string description, DateTime dueTo,
        Difficulty difficulty, int priority, UserId ownerId, List<ToDoTask> tasks
    ) : base(id)
    {
        Title = title;
        Description = description;
        DueTo = dueTo;
        Difficulty = difficulty;
        Priority = priority;
        OwnerId = ownerId;
        
        _tasks = tasks;
    }

    public static Deadline Create
    (
        DeadlineId id, string title, string? description, DateTime dueTo,
        Difficulty? difficulty, int? priority, UserId ownerId, List<ToDoTask> tasks
    ) => new
        (
            id,
            title,
            description ?? "",
            dueTo,
            difficulty ?? Difficulty.Easy,
            priority ?? int.MaxValue, 
            ownerId,
            tasks
        );

    public static Deadline CreateNew
    (
        string title, string? description, DateTime dueTo,
        Difficulty? difficulty, int? priority, UserId ownerId, List<ToDoTask> tasks
    ) => Create(DeadlineId.CreateUnique(), title, description, dueTo, difficulty, priority, ownerId, tasks);
}