namespace Domain.DeadlineAggregate.ValueObjects;

public class DeadlineId : ValueObjectBase, IId<DeadlineId, Guid>
{
    public Guid Value { get; }

    private DeadlineId(Guid value) => Value = value;

    public static DeadlineId Create(Guid value) => new(value);

    public static DeadlineId CreateUnique() => new(Guid.NewGuid());

    public static implicit operator string?(DeadlineId? id) => id?.Value.ToString();

    public static implicit operator DeadlineId?(string? str) => str is null ? null : new(Guid.Parse(str));
    
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}