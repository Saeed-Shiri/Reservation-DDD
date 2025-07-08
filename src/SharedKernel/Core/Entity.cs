

using System.Numerics;

namespace SharedKernel.Core;
public abstract class Entity<TId> where TId : notnull
{
    public TId Id { get; protected set; } = default!;

    protected Entity(TId id) => Id = id;

    public override bool Equals(object? obj)
    {
        if (obj is not Entity<TId> other)
            return false;

        if(ReferenceEquals(this, other)) return true;

        return Id.Equals(other.Id);
    }

    public override int GetHashCode() => Id.GetHashCode();

    public static bool operator ==(Entity<TId> left, Entity<TId> right) => left?.Equals(right) ?? right is null;
    public static bool operator !=(Entity<TId> left, Entity<TId> right) => !(left == right);

}

public abstract class Entity : Entity<Guid>
{
    protected Entity(Guid id) : base(id) { }
    protected Entity() : base(Guid.NewGuid()) { }
}
