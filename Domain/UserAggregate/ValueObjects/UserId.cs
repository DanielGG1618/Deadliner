namespace Domain.UserAggregate.ValueObjects;

public class UserId : ValueObjectBase, IId<UserId, Guid>
{
    public Guid Value { get; }

    private UserId(Guid value) => Value = value;

    public static UserId Create(Guid value) => new(value);

    public static UserId CreateUnique() => new(Guid.NewGuid());
    
    public static implicit operator string?(UserId? id) => id?.Value.ToString();

    public static implicit operator UserId?(string? str) => str is null ? null : new(Guid.Parse(str));
    
    protected override IEnumerable<object?> GetEqualityComponents() => [Value];

    public bool Equals(UserId? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return base.Equals(other) && Value.Equals(other.Value);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((UserId)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), Value);
    }
}
