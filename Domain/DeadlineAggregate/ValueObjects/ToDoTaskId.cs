namespace Domain.DeadlineAggregate.ValueObjects;

public class ToDoTaskId : ValueObjectBase, IId<ToDoTaskId, Guid>
{
    public Guid Value { get; }

    private ToDoTaskId(Guid value) => Value = value;

    public static ToDoTaskId Create(Guid value) => new(value);

    public static ToDoTaskId CreateUnique() => new(Guid.NewGuid());

    public static implicit operator string?(ToDoTaskId? id) => id?.Value.ToString();

    public static implicit operator ToDoTaskId?(string? str) => str is null ? null : Create(Guid.Parse(str));
    
    protected override IEnumerable<object?> GetEqualityComponents() => [Value];

    public bool Equals(ToDoTaskId? other) => other is not null && other.Value == Value;

    public override bool Equals(object? obj) => Equals(obj as ToDoTaskId);

    public override int GetHashCode() => Value.GetHashCode();
}