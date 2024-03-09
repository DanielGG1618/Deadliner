using Domain.DeadlineAggregate.ValueObjects;

namespace Domain.DeadlineAggregate;

public class Deadline : AggregateRoot<DeadlineId>
{
    public string Title { get; }
    public string Description { get; }

    private Deadline(DeadlineId id, string title, string description)
        : base(id)
    {
        Title = title;
        Description = description;
    }

    public static Deadline Create(DeadlineId id, string title, string description)
        => new(id, title, description);
}