﻿namespace Domain.Common.Models;

public interface IId<TSelf, TSource> : IEquatable<TSelf>
    where TSelf : IId<TSelf, TSource>
    where TSource : notnull
{
    public TSource Value { get; }

    public static abstract TSelf Create(TSource value);
    public static abstract TSelf CreateUnique();
    
    public static abstract implicit operator string?(TSelf? id);
    public static abstract implicit operator TSelf?(string? str);

    public bool Equals(IId<TSelf, TSource>? other)
    {
        if (ReferenceEquals(null, other)) return false;
        
        return ReferenceEquals(this, other) || Value.Equals(other.Value);
    }
}