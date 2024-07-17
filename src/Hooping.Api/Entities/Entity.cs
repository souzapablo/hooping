namespace Hooping.Api.Entities;
public abstract class Entity : IEquatable<Entity>
{
    public long Id { get; private init; }
    public DateTime CreatedAt { get; private set; } = DateTime.Now;
    public bool IsDeleted { get; private set; }

    protected void Delete() => IsDeleted = true;

    public static bool operator ==(Entity left, Entity right) =>
        left is not null 
        && right is not null
        && left.Equals(right);

    public static bool operator !=(Entity left, Entity right) => !left.Equals(right);

    public bool Equals(Entity? other)
    {
        if (other is null)
            return false;

        if (other.GetType() != GetType())
            return false;

        return other.Id == Id;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;

        if (obj.GetType() != GetType())
            return false;

        if (obj is not Entity other)
            return false;

        return other.Id == Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode() * 13;
    }
}
